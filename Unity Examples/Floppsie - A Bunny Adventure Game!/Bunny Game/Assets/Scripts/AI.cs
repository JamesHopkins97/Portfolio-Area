using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    Collider EnemyCollider;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb.gameObject.GetComponent<Rigidbody>();
        EnemyCollider = GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }
}
