using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, Time.deltaTime * 50, 0));
    }
}
