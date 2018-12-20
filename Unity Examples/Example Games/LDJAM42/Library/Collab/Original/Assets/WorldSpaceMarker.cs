using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceMarker : MonoBehaviour {

    public GameObject texture = null;

    [SerializeField]
    float boundary = 500;

    GameObject icon = null;
	// Use this for initialization
	void Start () {
		if(icon == null)
        {
            icon = Instantiate(texture);
            //icon.transform.parent = GameObject.Find("UI").transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
        updatePosition();
        updateVisibility();




    }

    void updateVisibility()
    {
        float x = icon.transform.position.x;
        float y = icon.transform.position.y;

        if ((x < Screen.width - boundary && x > boundary) && (y < Screen.height - boundary && y > boundary))
        {
            icon.GetComponent<Image>().enabled = false;
        }
        else
        {
            icon.GetComponent<Image>().enabled = true;
        }
    }

    void updatePosition()
    {
        Vector3 viewport = Camera.main.WorldToViewportPoint(transform.position);
        //Debug.Log(Camera.main.WorldToViewportPoint(transform.position));

        viewport.x *= Screen.width;
        viewport.y *= Screen.height;

        icon.transform.position = viewport;
        float x = icon.transform.position.x;
        float y = icon.transform.position.y;
        if (x > Screen.width - 50)
        {
            x = Screen.width - 50;
        }
        if (x < 50)
        {
            x = 50;
        }

        if (y > Screen.height - 50)
        {
            y = Screen.height - 50;
        }
        if (y < 50)
        {
            y = 50;
        }

        icon.transform.position = new Vector3(x, y, 0);
    }
}
