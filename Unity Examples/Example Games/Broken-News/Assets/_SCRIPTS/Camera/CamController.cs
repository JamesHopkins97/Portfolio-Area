using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

    public float speed; //speed variable
    private float translation; // forwards and backwards
    private float strafe; //left and right

    private float height;
    public float scrollSpeed = 1f;
    public float minY = 0.01f;
    public float maxY = 120f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        height = -1 * Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * 100f * Time.deltaTime;

    }

    void FixedUpdate()
    {
        transform.Translate(strafe, height, translation);
        Vector3 pos = transform.position;
        if (pos.y >= maxY) pos.y = maxY;
        if (pos.y <= minY) pos.y = minY;

        transform.position = pos;
    }
}
