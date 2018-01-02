using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    //Declare gameobjects
    private GameObject enemyFind;
    private Transform enemyCoords;
    public GameObject projectile;
    private GameObject TempBullet;
    private Rigidbody BulletRigidbody;

    private bool Firing = false;
    private Vector3 EnemyPoint;
    private float FireTimer = 3;
    private int count = 0;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Reduce the timer by runtime
        FireTimer -= Time.deltaTime;

        enemyFind = GameObject.Find("Enemy(Clone)");
        Vector3 scale = new Vector3(0.5f, 0.5f, 0.5f);
        Firing = CheckForEnemy();

        if (Input.GetKey(KeyCode.Space))
        {
            count++;
            if (count % 2 == 0)
                Firing = true;
            else
                Firing = false;

            if (Firing == false)
            {
                GetComponent<TurretRotation>().enabled = false;

                FindEnemy();
                EnemyPoint = enemyFind.transform.position - transform.position;
                Physics.Raycast(transform.position, EnemyPoint);
                // Debug.Log(projectile);
                if (FireTimer <= 0)
                {
                    // Instantiates bullet
                    TempBullet = Instantiate(projectile, transform.position, transform.rotation);
                    TempBullet.transform.localScale = (scale);
                    // Makes the bullet a child of the Turret
                    TempBullet.transform.parent = transform;
                    // Moves the bullet 
                    BulletRigidbody = TempBullet.GetComponent<Rigidbody>();
                    BulletRigidbody.AddForce(transform.forward * 10000);
                    // Gets Collider
                    // Reset timer
                    FireTimer = 0.03f;

                    // Destroys the bullet after 3 seconds
                    Destroy(TempBullet, 2);
                }
            }
            else
            {
                //If not firing, keep rotating.
                GetComponent<TurretRotation>().enabled = true;
            }
            //Debug.Log(Firing);
        }
    }

    void FindEnemy()
    {
        //Stops rotation
        GetComponent<TurretRotation>().enabled = false;
        // Finds the Enemy object
        enemyFind = GameObject.Find("Enemy(Clone)");
        // sets enemyCoords to the position of Enemy(Clone)
        enemyCoords = enemyFind.transform;
        // Turret looks at Enemy
        transform.LookAt(enemyCoords);
    }

    bool CheckForEnemy()
    {
        // If enemy object can be found, return false
        if (enemyFind == null)
            return true;
        else
            return false;
    }
}
