﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefugeeDetection : MonoBehaviour {

    private Collider[] hitColliders;
    public AudioManager AM;

    private int rngIniBruv; 
    // Use this for initialization

    void Start ()
    {
        if (AM == null) AM = GameObject.Find("GameManager").GetComponent<AudioManager>();

    }

    // Update is called once per frame
    void Update () {
        hitColliders = Physics.OverlapSphere(transform.position, 135.0f, 1 << LayerMask.NameToLayer("Refugee"));
        if (hitColliders.Length != 0.0f)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                RefugeeBehaviour refugeeScript = hitColliders[i].gameObject.GetComponent<RefugeeBehaviour>();

                refugeeScript.setMovementToBoat(true);

                //destroy the refugee if it gets too close
                if (Vector3.Distance(hitColliders[i].transform.position, gameObject.transform.position) <= 20.0f)
                {
                    ResourceList resourceList = gameObject.GetComponent<ResourceList>();

                    if (resourceList.getCurrentRemainingSpace() > 0)
                    {
                        Debug.Log("Time to die, Mr. Refugee!");
                        refugeeScript.destroyRefugee();
                        AM.PlayPickUpRefugeeNoise();
                        rngIniBruv = Random.Range(0, 5);
                        if (rngIniBruv == 3)
                        {
                            Debug.Log("IllPassenger !");
                            resourceList.AddRefugee(1);
                            resourceList.setCurrentMedicineResources(-1);
                        }
                        else
                        {
                            //add 1 refugee to the boat
                            resourceList.AddRefugee(1);
                        }
                    }
                }
            }
        }
    }
}