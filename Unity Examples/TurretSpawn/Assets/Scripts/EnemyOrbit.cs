using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrbit : MonoBehaviour
{

    private GameObject PlayerToOrbit;
    private float speed = 50.0f;
    private int num = 0;
    private Vector3 OrbitCoords;
	// Use this for initialization
	void Start ()
    {
        PlayerToOrbit = GameObject.Find("Turret2(Clone)");
        num = RNG();
        Debug.Log(num);
        OrbitCoords.Set(1, 1, 1);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (num == 0)
            transform.RotateAround(PlayerToOrbit.transform.position, Vector3.forward, speed * Time.deltaTime);
        else if (num == 1)
            transform.RotateAround(PlayerToOrbit.transform.position, Vector3.back, speed * Time.deltaTime);
        else if (num == 2)
            transform.RotateAround(PlayerToOrbit.transform.position, (Vector3.up + Vector3.forward), speed * Time.deltaTime);
        else if (num == 3)
            transform.RotateAround(PlayerToOrbit.transform.position, (Vector3.down + Vector3.forward), speed * Time.deltaTime);
        else if (num == 4)
            transform.RotateAround(PlayerToOrbit.transform.position, (Vector3.up + Vector3.back), speed * Time.deltaTime);
        else if (num == 5)
            transform.RotateAround(PlayerToOrbit.transform.position, (Vector3.down + Vector3.back), speed * Time.deltaTime);
        else if (num == 6)
            transform.RotateAround(PlayerToOrbit.transform.position, Vector3.up, speed * Time.deltaTime);
        else
            transform.RotateAround(PlayerToOrbit.transform.position, Vector3.down, speed * Time.deltaTime);
        
    }

    int RNG()
    {
            System.Random randomNumber = new System.Random();
            int rand = randomNumber.Next(0, 7);
            return rand;
    }
}
