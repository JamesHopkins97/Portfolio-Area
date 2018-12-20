using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternCoffeeHolding : MonoBehaviour {

    public int holdingCoffees = 0;
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void giveCoffee(Transform target)
    {
        if(holdingCoffees > 0)
        {
            holdingCoffees--;
            target.GetComponent<CharacterModifiers>().isCaffeinated = true;
            target.GetComponent<CharacterModifiers>().roundOfCaffeination = gm.turnCounter;
        }
        else
        {
            Debug.Log("No coffee to give :/");
        }
        
    }
}
