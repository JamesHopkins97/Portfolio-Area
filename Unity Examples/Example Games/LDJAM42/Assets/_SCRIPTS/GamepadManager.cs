using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GamepadManager : MonoBehaviour
{
    private bool gamepadConnected = false;
    private bool usingGamepad = false;

    // Use this for initialization
    private void Start () {}

    // Update is called once per frame
    private void Update()
    {
        //check if the player is using a gamepad or a keyboard and mouse
        if (ControllerCheck())
        {
            if (Input.anyKey)
            {
                foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
                {
                    //do something with kcode
                    if (Input.GetKeyDown(kcode))
                    {
                        if (kcode >= (KeyCode)350 && kcode <= (KeyCode)369)
                            usingGamepad = true;
                        else
                            usingGamepad = false;
                    }
                }
            }
        }
    }

    //checks if any controllers are plugged in
    private bool ControllerCheck()
    {
        //Get Joystick Names
        string[] temp = Input.GetJoystickNames();

        //Check whether array contains anything
        if (temp.Length > 0)
        {
            //Iterate over every element
            for (int i = 0; i < temp.Length; ++i)
            {
                //Check if the string is empty or not
                if (!string.IsNullOrEmpty(temp[i]))
                {
                    //Not empty, controller temp[i] is connected
                    return true;
                }
            }
        }
        return false;
    }

    public bool getGamePadDetected()
    {
        if (gamepadConnected)
            return true;

        return false;
    }

    public bool getUsingGamepad()
    {
        if (usingGamepad)
            return true;

        return false;
    }
}
