using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveHandler : MonoBehaviour {

    private ScoreManager sm;
	// Use this for initialization
	void Start () {
        sm = GameObject.Find("GameManager").GetComponent<ScoreManager>();
	}

    public string latestLevel()
    {
        List<string> listToUse = FileHandler.readLines(Application.dataPath + "/Data/save.txt");
        return listToUse[0];
    }

    void saveGame()
    {
        List<string> saveToFile = new List<string>();
        saveToFile.Add(SceneManager.GetActiveScene().name);
        if(sm != null)
        {
            saveToFile.Add(sm.score.ToString());
        }
        

        FileHandler.writeLines(Application.dataPath + "/Data/save.txt", saveToFile);
    }
}
