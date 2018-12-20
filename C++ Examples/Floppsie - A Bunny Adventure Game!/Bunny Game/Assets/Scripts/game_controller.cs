using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class game_controller : MonoBehaviour
{
    public Transform PauseMenu;
    public GameObject player;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }


    public void Pause()
    {
        
            //Pauses the game
            if (PauseMenu.gameObject.activeInHierarchy == false)
            {
                PauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
                player.GetComponent<CamMouseLook>().pause = true;
                Cursor.lockState = CursorLockMode.None; //Unlocks the cursor remove during this from camlock if there
            }
            else
            //Unpauses the game
            {
                PauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
                player.GetComponent<CamMouseLook>().pause = false;
                Cursor.lockState = CursorLockMode.Locked; //Locks the cursor so that it can not leave the game window
            }
    }

    public void exit_game()
    {
        Application.Quit();
    }
}
