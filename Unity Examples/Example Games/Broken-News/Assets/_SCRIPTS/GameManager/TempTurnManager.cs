using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempTurnManager : MonoBehaviour {

    ScoreManager sc;
    GameManager gm;
	// Use this for initialization
	void Start () {
        gm = this.GetComponent<GameManager>();
        sc = gm.scoreManager;
        InvokeRepeating("OneSecondUpdate", 0f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Return)) && gm.getPlayerTurn())
        {
            gm.EndTurn();
        }
	}
    void OneSecondUpdate()
    {
        if (gm.getPlayerTurn())
        {
            if (gm.checkTurns()) gm.EndTurn();
        }
        
    }
}
