using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTurret : MonoBehaviour
{
    private float time = 1.0f;
    int num;
    public GameObject Turret2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // On mouse button 1 click
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray newRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(newRay, out hit))
            {
                //Turret2.transform.localScale = new Vector3(1000, 1000, 1000);
                Instantiate(Turret2, hit.point, transform.localRotation);
                Debug.Log("PRESSED");
            }
        }
    }
}