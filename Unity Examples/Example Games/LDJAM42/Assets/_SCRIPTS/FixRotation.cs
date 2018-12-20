using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour {
    public bool LockRotation = true;
    public bool LockPosition = true;

    Quaternion rotation;
    Vector3 position;

    void Awake()
    {
        rotation = transform.rotation;
        position = transform.position;
    }
    void LateUpdate()
    {
        if (LockRotation)
            transform.rotation = rotation;

        if (LockPosition)
            transform.position = position;
    }
}
