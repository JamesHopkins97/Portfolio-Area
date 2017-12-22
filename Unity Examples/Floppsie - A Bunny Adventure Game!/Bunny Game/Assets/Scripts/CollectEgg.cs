using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
Checks if player is in range (basically inside the egg collider) and when user presses E while in range, the egg is collected and +1 is added to a count labelled "Eggs Collected".
*/

public class CollectEgg : MonoBehaviour
{
    private int EggCount;
    public Text EggCountText;
    // Use this for initialization
    void Start()
    {
        EggCount = 0;
        SetEggCountText();
    }

    void OnTriggerStay(Collider other) //OnTriggerStay == When two objects keep overlapping each other, rather than OnTriggerEnter = Only when first overlap contact is made
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");
            if (other.gameObject.CompareTag("Collectable"))
            {
                other.gameObject.SetActive(false);//Set the egg the player is standing in to an inactive state       
                EggCount = EggCount + 1; //Increment the egg counter
                SetEggCountText();
                Cursor.lockState = CursorLockMode.None; //Locks the cursor so that it can not leave the game window
                SceneManager.LoadSceneAsync("PairsGame");
            }
        }
    }

    void SetEggCountText()
    {
        //Shows egg collected counter.
        EggCountText.text = "Eggs collected: " + EggCount.ToString();
    }


}
 