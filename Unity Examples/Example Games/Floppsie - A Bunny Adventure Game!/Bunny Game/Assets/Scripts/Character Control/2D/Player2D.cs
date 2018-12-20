using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{

    //Variables
    public float speed = 50f; //How fast the player moves
    public float MaxSpeed = 3; // used to set a limit of how fast (accerleration?) the player moves.
    public float JumpPower = 150f; //How high the player jumps

    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(Vector2.up * JumpPower); //Adds upwards force to player when Jump button is pressed
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); //Gets the input of left/right from the player and puts it into the float variable 'h'

        rb2d.AddForce((Vector2.right * speed) * h); // Moves players based on if they press left or right arrow

        //Speed limiters for the player movement
        if (rb2d.velocity.x > MaxSpeed)
            rb2d.velocity = new Vector2(MaxSpeed, rb2d.velocity.y);

        if (rb2d.velocity.x < -MaxSpeed)
            rb2d.velocity = new Vector2(-MaxSpeed, rb2d.velocity.y);
    }
}