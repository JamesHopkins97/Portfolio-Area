using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    private SaveHandler sh;
    public string LevelName;
    //Use this for initialization
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(StartGame);
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(LevelName);
    }
}
