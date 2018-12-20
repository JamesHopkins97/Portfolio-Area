using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private NavMeshAgent SpeshulAgent;
    private Transform PanelTarget;

    CharacterModifiers charMod;
    //public GameObject Player;
    GameObject[] Panels;
    GameObject PanelMove;
    int count = 0;
    Collider[] ColliderHitData;
    int LayerMask = ~(1 << 9);

    private void Start()
    {
        charMod = GetComponent<CharacterModifiers>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (GetPanelToGo.GetPanel() != null)
        {
            PanelMove = GetPanelToGo.GetPanel();
            PanelTarget = PanelMove.transform;
            ColliderHitData = Physics.OverlapSphere(transform.position, charMod.moveDistance, LayerMask);
            
            if (Proceed())
                MovePlayer();

        }
    }

    bool Proceed()
    {
        //int count = ColliderHitData.Length;
        //bool proceed = false;
        //for (int i = 0; i < count; i++)
        //{
        //    if (PanelMove != ColliderHitData[i])
        //        proceed = true;                
        //}

        bool proceed = false;

        if(ColliderHitData.Length != 0)
        {
            for(int i = 0; i < ColliderHitData.Length; i++)
            {
                if(ColliderHitData[i].gameObject == PanelMove)
                {
                    proceed = true;
                }
            }
        }
        Debug.Log(proceed);
        return proceed;
    }

    public void MovePlayer()
    {
        SpeshulAgent.SetDestination(PanelTarget.position);
        PanelMove = null;
    }

}

static public class GetPanelToGo
{
    static GameObject PanelToGo;

    static public void SetPanel(GameObject Panel)
    {
        PanelToGo = Panel;
    }

    static public GameObject GetPanel()
    {
        return PanelToGo;
    }
}