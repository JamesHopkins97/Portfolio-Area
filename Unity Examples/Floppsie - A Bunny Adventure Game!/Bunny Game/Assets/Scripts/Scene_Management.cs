using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Scene_Management : MonoBehaviour {

    string[] PuzzleScene = { "PairsGame", "PairsGame", "PairsGame", "PairsGame", "PairsGame", "PairsGame", "PairsGame", "PairsGame", "PairsGame", "PairsGame" };
	// Use this for initialization
	public void Start () {
        //SceneManager.LoadSceneAsync(PuzzleScene[0]);
        Cursor.lockState = CursorLockMode.None; //Locks the cursor so that it can not leave the game window
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(PuzzleScene[RNG()]);
        if (Input.GetKeyDown(KeyCode.E))
            SceneManager.LoadSceneAsync("PairsGame");

    }

    int RNG()
    {
        System.Random randomNumber = new System.Random();
        int rand = randomNumber.Next(0, 10);
        return rand;
    }
}
