using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(LineRenderer))]
public class RadiusDisplay : MonoBehaviour
{
    // https://gamedev.stackexchange.com/questions/126427/draw-circle-around-gameobject-to-indicate-radius

    private int segments = 50;

    private float attackRadius, moveRadius, viewRadius;

    private void Start()
    {
        attackRadius = this.GetComponent<CharacterModifiers>().attackDistance;
        moveRadius = this.GetComponent<CharacterModifiers>().tempMoveDistance;
        viewRadius = this.GetComponent<CharacterModifiers>().viewDistance;
    }
    LineRenderer line;


    // Use this for initialization
    public void DrawPoints()
    {
        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        line.startColor = Color.black;
        line.endColor = Color.blue;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        CreatePoints();
    }

    void CreatePoints()
    {
        float x;
        float z;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * moveRadius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * moveRadius;

            line.SetPosition(i, new Vector3(x, 0, z));

            angle += (360f / segments);
        }
    }

    // Update is called once per frame
    void Update()
    {
       moveRadius = this.GetComponent<CharacterModifiers>().tempMoveDistance;
    }
}
