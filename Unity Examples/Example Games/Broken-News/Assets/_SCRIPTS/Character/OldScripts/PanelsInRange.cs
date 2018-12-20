using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsInRange : MonoBehaviour {
    Collider[] ColliderHitData;
    public GameObject Character;
    public Material InRange;
        GameObject Panel;

    private void OnMouseDown()
    {
        int LayerMask = ~(1 << 9);
        Collider[] ColliderHitData = Physics.OverlapSphere(transform.position, 14.0f, LayerMask);
        int count = 0;
        //ReturnArray.SetPanel(ColliderHitData);
        while (count < ColliderHitData.Length)
        {
            Debug.Log(ColliderHitData[count]);
            ColliderHitData[count].GetComponent<Renderer>().material = InRange;
            count++;
        }
    }
}

static public class ReturnArray
{
    static Collider[] Array;
    static int i = 0;
    static public void SetPanel(Collider[] PanelCollider)
    {
        while (i < PanelCollider.Length)
            Array[i] = PanelCollider[i];
    }

    static public Collider[] GetPanel()
    {
        return Array;
    }
}
