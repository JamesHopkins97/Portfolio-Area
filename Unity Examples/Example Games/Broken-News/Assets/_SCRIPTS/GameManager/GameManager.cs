using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour {

    private bool playerTurn = true;
    public int score = 0;
    public int turnCounter = 0;
    public List<GameObject> Enemies;
    public List<GameObject> Players;

    public GameObject targetPrefabForPlayers;

    public ScoreManager scoreManager;
	// Use this for initialization
	void Start () {
        Players[0] = GameObject.Find("Reporter");
        Players[1] = GameObject.Find("CameraMan");
        Players[2] = GameObject.Find("MicMan");
        Players[3] = GameObject.Find("Intern");
        scoreManager = GetComponent<ScoreManager>();


        GameObject[] tempgo = Util.FindObjectsWithLayer(LayerMask.NameToLayer("Enemy"));
        for (int i = 0; i < tempgo.Length; i++)
        {
            Enemies.Add(tempgo[i]);
        }
    }

    public void EndTurn()
    {
        playerTurn = false;

        //Do enemy stuff here
        foreach (GameObject g in Players)
        {
            CharacterModifiers chmod = g.GetComponent<CharacterModifiers>();
            g.transform.position = Vector3.MoveTowards(g.transform.position, g.GetComponent<NavMeshAgent>().destination, chmod.tempMoveDistance);
            g.GetComponent<LineRenderer>().enabled = false;
            if (chmod.hasMove)
            {
                chmod.hasMove = true;
            }
        }
        foreach(GameObject g in Enemies)
        {
            g.GetComponent<EnemyAI>().moveAI();
        }
        Debug.Log("Starting turn in 3 seconds");
        Invoke("StartTurn", 3f);
    }

    public void StartTurn()
    {
        turnCounter++;
        Debug.Log("Turn started");
        foreach (GameObject g in Players)
        {
            
            CharacterModifiers chmod = g.GetComponent<CharacterModifiers>();
            if (!chmod.hasMove)
            {
                chmod.hasMove = true;
            }
            g.GetComponent<CharacterModifiers>().tempMoveDistance = chmod.moveDistance;
        }
        playerTurn = true;
    }
    public bool checkTurns()
    {
        int moveCounter = 0;
        foreach(GameObject g in Players)
        {
            CharacterModifiers chmod = g.GetComponent<CharacterModifiers>();
            if (chmod.hasMove)
            {
                moveCounter++;

            }
        }
        if (moveCounter != 0) return false;
        return true;
    }

    public bool getPlayerTurn()
    {
        return playerTurn;
    }
    public bool getEnemyTurn()
    {
        return !playerTurn;
    }
    public void setPlayerTurn(bool turn)
    {
        playerTurn = turn;
    }
    public void setEnemyTurn(bool turn)
    {
        playerTurn = !turn;
    }

}
