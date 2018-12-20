using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        var playerObject = GameObject.Find("Player");
        //var TeleporterExit = GameObject.Find("TeleporterExit"); //(Create an empty gameobject and add the tag "TeleporterExit" to it)
        Debug.Log("Player entered the portal.");
        SceneManager.LoadSceneAsync("Scene 2");
        //playerObject.transform.position = TeleporterExit.transform.position; //player position = where the teleporter exit is
    }

}
