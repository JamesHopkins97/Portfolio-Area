using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject Bar;
    private GameObject Bullet;
    public static float Health = 0;

	// Use this for initialization
	void Start ()
    {
        Health = 1000;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // find bullet
        Bullet = GameObject.Find("Projectile(Clone)");
        // If health hits zero, destroy enemy
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        // if bullet has tag, destroy bullet and take 10 away from health
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(Bullet);
            Health -= 10;
            //Debug.Log(Health);
        }
    }

    public static float returnHealth()
    {
        return Health;
    }
}
