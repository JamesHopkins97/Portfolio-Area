using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    public GameObject Turret2;
    int num = 0;
    int count = 0;
    // Use this for initialization
    void Start()
    {
        num = RNG();
    }

    // Update is called once per frame
    void Update()
    {
        if (num == 0)
        {
            transform.Rotate(new Vector3(Time.deltaTime * 50, Time.deltaTime * 50, 0));
        }
        if (num == 1)
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * 50, Time.deltaTime * 50));
        }
        if (num == 2)
        {
            transform.Rotate(new Vector3(Time.deltaTime * 50, 0, Time.deltaTime * 50));
        }
        if (num == 3)
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * 50, 0));
        }
        if (num == 4)
        {
            transform.Rotate(new Vector3(Time.deltaTime * 50, 0, 0));
        }
        if (num == 5)
        {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * 50));
        }
        count++;
        //Debug.Log(count);
        if (count == 200)
        {
            num = RNG();
            count = 0;
        }

    }

    int RNG()
    {
        System.Random randomNumber = new System.Random();
        int rand = randomNumber.Next(0, 5);
        return rand;
    }
}