using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using cakeslice;
//IMPORTANT !!!!!!!!!!
//LIGHTS ON SELECTOR CHILD MAY NEED TO BE ADJUSTED FOR DIFFERENT OBJECTS
//Lighting settings will also have to be adjusted in the end
public class characterSelect : MonoBehaviour
{
    //used to reference selector light

    private CharacterModifiers select;
    private GameManager gm;
    private RadiusDisplay mm;
    private Text text;

    public bool isActivated = false;

	// Use this for initialization
	void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        select = this.GetComponent<CharacterModifiers>();
        mm = this.GetComponent<RadiusDisplay>();
        text = GameObject.Find("Canvas/selected").GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            wasItMe();
        }
    }
    private void wasItMe()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == this.name)
            {
                activateCharacter();
                isActivated = true;
            }
            else
            {
                isActivated = false;
            }
        }
    }

    public void activateCharacter()
    {
        select.characterSelected = !select.characterSelected;
        if (select.characterSelected)
        {
            GetComponent<cakeslice.Outline>().color = 0;
            text.text = this.name;
        }

        else
            GetComponent<cakeslice.Outline>().color = 1;
        mm.DrawPoints();
        this.GetComponent<LineRenderer>().enabled = select.characterSelected;

        foreach (GameObject g in gm.Players)
        {
            if (g != transform.gameObject)
            {
                g.GetComponent<CharacterModifiers>().characterSelected = false;
                g.GetComponent<cakeslice.Outline>().color = 1;
                g.GetComponent<LineRenderer>().enabled = false;
            }
        }
    }
}