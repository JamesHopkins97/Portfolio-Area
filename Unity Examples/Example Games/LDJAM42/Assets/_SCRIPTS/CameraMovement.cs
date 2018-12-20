using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //[SerializeField]
    //private float smoothTime = 0.3f;

    [SerializeField]
    private float rotationSensitivity = 0.2f;

    [SerializeField]
    private float zoomSensitivity = 5000f;

    [SerializeField]
    private float distance = 250f;

    [SerializeField]
    private float minDistance = 35.0f;

    [SerializeField]
    private float maxDistance = 550.0f;

    private GameObject boat;

    private GamepadManager gamepadManager;

    private Movement ShipMovement = null;

    // Use this for initialization
    void Start ()
    {
        //get the boat game object
        boat = transform.parent.gameObject;

        //get the boat movement script
        ShipMovement = boat.GetComponent<Movement>();

        //get the gamepad manager
        gamepadManager = GameObject.Find("GameManager").GetComponent<GamepadManager>();

        //set the inital camera position
        transform.position = boat.transform.position + new Vector3(0, distance, -distance);
    }

    // Update is called once per frame
    void Update()
    {
        //allow rotatation of the camera around the ship
        if (Input.GetButton("Mouse Down") || (gamepadManager.getUsingGamepad()))
            transform.RotateAround(boat.transform.position, Vector3.up, (Input.GetAxis("Mouse X") * 100) * rotationSensitivity);

        //allow camera scrolling and constraint the min and max range of it
        Vector3 scrollVector = Vector3.forward * (Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity) * Time.deltaTime;

        if (transform.position.y - scrollVector.z > maxDistance) scrollVector.z = -(maxDistance - transform.position.y);
        else if (transform.position.y - scrollVector.z < minDistance) scrollVector.z = -(minDistance - transform.position.y);

        transform.Translate(scrollVector);
    }

    private void FixedUpdate()
    {
        //counter the boat movement, so that it doesn't rotate with the boat
        float input = Input.GetAxisRaw("Horizontal");
        if (input != 0)
        {
            input *= ShipMovement.getRotation();
            transform.RotateAround(boat.transform.position, Vector3.up, -input);
        }
    }
}
