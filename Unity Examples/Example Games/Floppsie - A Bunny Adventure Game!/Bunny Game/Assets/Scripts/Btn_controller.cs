using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_controller : MonoBehaviour
{

	public void new_game(string new_level)
    {
        SceneManager.LoadScene(new_level);
    }

    public void exit_game()
    {
        Application.Quit();
    }
}
