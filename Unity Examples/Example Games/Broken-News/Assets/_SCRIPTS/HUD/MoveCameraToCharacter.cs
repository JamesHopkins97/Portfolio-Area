using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class MoveCameraToCharacter : MonoBehaviour
{

     public Camera mainCamera;

     public GameObject Character;


    //public Transform target;


     public void OnMouseDown()
    {
        //Vector3 relativePos = target.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(relativePos);
        //transform.rotation = rotation

        CamRotation camRot = mainCamera.GetComponent<CamRotation>();

        mainCamera.transform.parent.transform.position = Vector3.MoveTowards(mainCamera.transform.position, Character.transform.position, (Vector3.Distance(mainCamera.transform.position, Character.transform.position)- 20f));

        Character.GetComponent<characterSelect>().activateCharacter();

        camRot.lookAtTarget(Character.transform);

    }

    private void Update()
    {
        
    }

}