using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turns : MonoBehaviour {

    public Text TurnsRemaining;

    int turns = 20;
	

    public void OnMouseDown()
    {
        turns = turns - 1;


        if (turns <= 0)
        {
            TurnsRemaining.text = "Turns remaining: " + 0;
            Debug.Log("You have run out of movesss.");
        }

        else
        {
            TurnsRemaining.text = "Turns remaining: " + turns.ToString();
            Debug.Log("Keep doing da movey move.");
        }


    }

}
