using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(LineRenderer))]
public class MovementMarker : MonoBehaviour
{
    // https://gamedev.stackexchange.com/questions/126427/draw-circle-around-gameobject-to-indicate-radius
    private GameObject host;
    private GameObject Character;

    // Update is called once per frame
    void Update()
    {
        if (host != null)
        {
            ifNotTarget();
        }

    }

    public void ifNotTarget()
    {
        if (host.GetComponent<PlayerMovement>().getTarget() != gameObject)
        {
            Destroy(this.gameObject);
        }
    }

    public void setHost(GameObject go)
    {
        host = go;
    }
}
