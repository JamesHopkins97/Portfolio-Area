using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {
    public float speed = 10.0F; //How fast the player moves
    public float JumpPower = 10f; //How high the player jumps


    Collider PlayerCollider;
    float DistanceToGround;
    bool JumpedTwice;
    
    Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked; //Locks the cursor so that it can not leave the game window
        rb = gameObject.GetComponent<Rigidbody>();
        PlayerCollider = GetComponent<Collider>();
        DistanceToGround = PlayerCollider.bounds.extents.y;
        JumpedTwice = false;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, DistanceToGround + 0.1f);
    }


    // Update is called once per frame
    void Update ()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);


        if (Input.GetButtonDown("Jump") && IsGrounded()) //If user press the jump button and the player object is currently grounde
            rb.velocity = new Vector3(0, JumpPower, 0); //Adds upwards force to player when Jump button is pressed



        if (Input.GetButtonDown("Jump") && !IsGrounded() && !JumpedTwice) //Checks if player is off ground, and if they have already done a double jump
        {
            rb.velocity = new Vector3(0, JumpPower, 0); //Adds upwards force to player when Jump button is pressed

            JumpedTwice = true; //Player has done a double jump
        }

        if (IsGrounded())
            JumpedTwice = false;
    }
}
