using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTurret : MonoBehaviour
{
    int num;
    public GameObject TurretCube;
    bool Spawned = false;

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (Spawned == false)
        {
            // On mouse button 1 click
            if (Input.GetKey(KeyCode.Mouse0))
            {
                // Spawn cube
                RaycastHit hit;
                Ray newRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(newRay, out hit))
                {
                    // Instantiates the new turret where the mouse is clicked
                    Instantiate(TurretCube, hit.point, transform.localRotation);

                    //Enables EnemySpawner Script
                    GetComponent<EnemySpawner>().enabled = true;
                    GetComponent<HealthDisplay>().enabled = true;
                    Spawned = true;
                }
            }
        }
    }
}
