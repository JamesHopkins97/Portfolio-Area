using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public Transform objective;
    private List<GameObject> Players;
    public GameManager gameManager;
    public float camMultiplier = 3;

    public int maxScore;

    private GameObject reporter, cameraMan, intern, micMan;
    public int score = 0;

	// Use this for initialization
	void Start () {
        Players = gameManager.Players;
        foreach (GameObject g in Players)
        {
            if (g.name == "Reporter")
            {
                reporter = g;

            }
            if (g.name == "CameraMan")
            {
                cameraMan = g;
            }
            if (g.name == "Intern")
            {
                intern = g;
            }
            if (g.name == "MicMan")
            {
                micMan = g;
            }
        }
        float reporterScore;
        float cameraScore;
        float micScore;
        reporterScore = reporter.GetComponent<CharacterModifiers>().maxHealth;
        cameraScore = cameraMan.GetComponent<CharacterModifiers>().maxHealth;
        micScore = micMan.GetComponent<CharacterModifiers>().maxHealth;
        cameraScore *= 5;
        reporterScore += 199f;
        micScore *= 1.5f;

        maxScore = (int)(reporterScore + cameraScore + micScore);
    }

    // Update is called once per frame
    void Update() {
        float reporterScore;
        float cameraScore;
        float micScore;
        

        reporterScore = reporter.GetComponent<CharacterModifiers>().maxHealth;
        cameraScore = cameraMan.GetComponent<CharacterModifiers>().maxHealth;
        micScore = micMan.GetComponent<CharacterModifiers>().maxHealth;

        float tempCamAdd = 200f - Vector3.Distance(objective.position, cameraMan.transform.position);
        if (tempCamAdd >= 0)
            reporterScore += tempCamAdd;

        cameraScore *= camMultiplier;

        if (micMan.GetComponent<CharacterModifiers>().isCaffeinated)
        {
            micScore *= 1.5f;
        }

        score = (int)(reporterScore + cameraScore + micScore);

    }
}
