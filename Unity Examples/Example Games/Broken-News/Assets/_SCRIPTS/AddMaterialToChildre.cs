using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMaterialToChildre : MonoBehaviour {

    // Use this for initialization

    public Material material;
	void Start () {
        Renderer[] children;
        children = GetComponentsInChildren<Renderer>();
        foreach(Renderer r in children)
        {
            Material[] mats = new Material[r.materials.Length];
            for (int j = 0; j < r.materials.Length; j++)
            {
                mats[j] = material;
            }
            r.materials = mats;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
