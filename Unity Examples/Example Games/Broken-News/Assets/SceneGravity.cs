using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics.gravity = new Vector3(0, -1.0F, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
