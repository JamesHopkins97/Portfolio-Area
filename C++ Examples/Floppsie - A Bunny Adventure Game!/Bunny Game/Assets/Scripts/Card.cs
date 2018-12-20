using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public static bool DO_NOT = false;

    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = false;

    private Sprite _cardBack;
    private Sprite _cardFace;

    private GameObject _manager;

    void Start()
    {
        _state = 1;
        _manager = GameObject.FindGameObjectWithTag("Manager");
    }

	public void setupGraphics()
    {
        _cardBack = _manager.GetComponent<GameManager>().getCardBack();
        _cardFace = _manager.GetComponent<GameManager>().getCardFace(_cardValue);

        flipCard();
    }


    public void flipCard()
    {
        if (_state == 0)
        {
            _state = 1;
        }
        else if (_state == 1)
        {
            _state = 0;
        }

        if (_state == 0 && !DO_NOT)
        {
            GetComponent<Image>().sprite = _cardBack;
        }

        else if (_state == 1 && !DO_NOT)
        {
            GetComponent<Image>().sprite = _cardFace;
        }

        
    }


    public int cardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }
    //puts the cards in a temporary checking state
    public int state
    {
        get { return _state; }
        set { _state = value; }
    }

    public bool initialized
    {
        get { return _initialized; }
        set { _initialized = value; }
    }

    //Allows us to pause the game and wait for a second so the player can look at the cards. 
    public void falseCheck()
    {
        StartCoroutine(cheese());
    }

    IEnumerator cheese()
    {
        yield return new WaitForSeconds(0.5f);
        if (_state == 0)
        {
            GetComponent <Image> ().sprite = _cardBack;
        }

        else if (state == 1)
        {
            GetComponent<Image>().sprite = _cardFace;
        }
        DO_NOT = false;
    }
     
}

