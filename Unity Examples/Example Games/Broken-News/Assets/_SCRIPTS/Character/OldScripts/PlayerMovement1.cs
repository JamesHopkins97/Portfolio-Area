using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum playerType { Reporter, CameraMan, MicMan, Intern };

public class PlayerMovement1 : MonoBehaviour {

    
    [SerializeField] private NavMeshAgent SpeshulAgent;
    private Transform PanelTarget;

    CharacterModifiers charMod;
    //public GameObject Player;
    GameObject[] Panels;
    GameObject PanelMove;
    int count = 0;
    public bool check = false;
    Collider[] ColliderHitData;
    int LayerMask = ~(1 << 9);
    GetPanelToGo ptg;
    //public void Move()
    //{
    //    if (GetPanelToGo.GetPanel() != null)
    //    {
    //        PanelMove = GetPanelToGo.GetPanel();
    //        PanelTarget = PanelMove.transform;
    //        ColliderHitData = Physics.OverlapSphere(transform.position, charMod.moveDistance, LayerMask);

    //        if (Proceed())
    //        {

    //        }
    //    }
    //}

    //Update is called once per frame
    public void Update()
    {
        if (!check)
        {
            if (ptg.GetPanel() != null)
            {
                PanelMove = ptg.GetPanel();
                PanelTarget = PanelMove.transform;
                ColliderHitData = Physics.OverlapSphere(transform.position, charMod.moveDistance, LayerMask);

                if (Proceed())
                {
                    SpeshulAgent.SetDestination(PanelTarget.position);
                    PanelMove = null;
                    check = true;
                }
            }
        }
        else
        {
            //if (check)
                Cheque();
        }        
    }


    public bool Cheque()
    {
        if (this.transform == ptg.GetPanel())
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    

    private void Start()
    {
        charMod = GetComponent<CharacterModifiers>();
    }


    bool Proceed()
    {

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
        return proceed;
    }

    public void MovePlayer()
    {

    }

}

public class GetPanelToGo : MonoBehaviour
{

    GameObject PanelToGo;

    public void SetPanel(GameObject Panel)
    {
        PanelToGo = Panel;
        //GetComponent<CharacterModifiers>().hasMove = false;
    }

    public GameObject GetPanel()
    {
        
        return PanelToGo;
    }
}