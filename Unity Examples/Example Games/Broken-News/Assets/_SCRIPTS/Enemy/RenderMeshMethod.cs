using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderMeshMethod : MonoBehaviour {

    public int countDown = 0;
    private void LateUpdate()
    {
        if(countDown <= 0)
        {
            if(gameObject.GetComponentInChildren<Renderer>().enabled)
                gameObject.GetComponentInChildren<Renderer>().enabled = false;
        }
        else
        {
            countDown--;
        }
    }
}
