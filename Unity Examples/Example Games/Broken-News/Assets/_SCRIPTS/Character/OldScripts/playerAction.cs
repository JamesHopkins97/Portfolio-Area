using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAction : MonoBehaviour
{
    private GameManager gm;
    private CharacterModifiers modifiers;
    private CharacterAttack attack;
    private PlayerMovement pm;
	// Use this for initialization
	void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        modifiers = gameObject.GetComponent<CharacterModifiers>();
        attack = gameObject.GetComponent<CharacterAttack>();
	}


    // Update is called once per frame
    void Update ()
    {
        foreach (GameObject g in gm.Players)
        {
            //checking all characters for has move and if theyre selected NOTE:only one character can be selected at a time
            //so only one player object will pass through at any given time
            if (g.GetComponent<CharacterModifiers>().hasMove && g.GetComponent<CharacterModifiers>().characterSelected)
            {
                //checking for lmb
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    //Will likely need to change panels option

                    if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Panels")
                    {
                        Debug.Log("Press enter key if you want to move");
                        if (Input.GetButtonDown("Return"))
                        {
                            Debug.Log("Player should move");
                            //call movement function IMPORTANT MAKE SURE TO INCLUDE!!!

                            //setting has move for particular character to false
                           // g.GetComponent<CharacterModifiers>().hasMove = false;
                        }
                        else if (!Input.GetButtonDown("None"))
                        {
                            Debug.Log("You decided to not move");
                        }
                    }
                }
            }
        }
        //if (modifiers.hasMove)
        //{
        //    //making sure that a player character has been selected
        //    if (modifiers.characterSelected)
        //    {
        //        //checking for lmb down
        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            RaycastHit hit;
        //            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Panels")
        //            {
        //                Debug.Log("Sup homie hit dat enter key if you wanna move");
        //                if (Input.GetButtonDown("Return"))
        //                {
        //                    //calling function for movement
        //                    //setting character has move to false after they have moved
        //                    modifiers.hasMove = false;
        //                }
        //                else if (!Input.GetButtonDown("None"))
        //                {
        //                    Debug.Log("Okie you stay there then");
        //                }
        //            }            
        //            else if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Enemy")
        //            {
        //                //asking user to press enter key to confirm attack
        //                Debug.Log("Yo my dawg if you're sure you wanna hit dis dude press enter");
        //                if (Input.GetButtonDown("Return"))
        //                {
        //                    //calling function for attack
        //                    if (attack.CanAttack(hit.transform.gameObject) == 1)
        //                    {
        //                        //if player can attack hasmove is used
        //                        modifiers.hasMove = false;
        //                    }
        //                    else if (attack.CanAttack(hit.transform.gameObject) == 2)
        //                    {
        //                        //if player cannot attack then has move is not used
        //                        modifiers.hasMove = true;
        //                    }
        //                }
        //                else if (!Input.GetButtonDown("None"))
        //                {
        //                    Debug.Log("Aight fam thas coolio, you a pacifist");
        //                }
        //            }
        //        }
        //    }
        //}
	}
}
