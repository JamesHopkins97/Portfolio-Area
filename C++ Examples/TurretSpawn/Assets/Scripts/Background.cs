using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public Material frontPlane;
	// Use this for initialization
	void Start () {
        //Creates the plane
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);

        //loads the image from disk
        var filePath = "C:/Users/James/Music/Game Dev/Work/Unity/TurretSpawn/space.png";

        if (System.IO.File.Exists(filePath))
        {
            //Image file exists, so load the bytes into a texture
            var bytes = System.IO.File.ReadAllBytes(filePath);
            var tex = new Texture2D(1, 1);
            tex.LoadImage(bytes);
            frontPlane.mainTexture = tex;

            //apply to the plane
            MeshRenderer mr = plane.GetComponent<MeshRenderer>();
            mr.material = frontPlane;
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
