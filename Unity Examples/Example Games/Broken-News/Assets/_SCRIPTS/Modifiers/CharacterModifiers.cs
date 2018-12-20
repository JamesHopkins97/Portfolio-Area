using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModifiers : MonoBehaviour {
    public float maxHealth;
    public float healthMofidier;
    public float moveDistance;
    public float viewDistance;
    public float attackDistance;
    public float critModifier;
    public float maxDamage;
    public bool hasMove = true;
    public bool isCaffeinated = false;
    public float tempMoveDistance = 20;
    public bool characterSelected = false;
    

    public int roundOfCaffeination = -1;

    private float tempHealth = 0;

    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void FixedUpdate()
    {
        tempHealth = maxHealth;
        if(roundOfCaffeination + 3 <= gm.turnCounter && isCaffeinated)
        {
            isCaffeinated = false;
        }
    }
}
