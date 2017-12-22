using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text matchText;

    private bool _init = false;
    private int _matches = 13;

	
	// Update is called once per frame
	void Update ()
    {
		if (!_init)
        {
            initializeCards();
        }

        //everytime someone clicks on a card. it will check if there are 2 face up cards.
        if (Input.GetMouseButtonUp(0))
        {
            checkCards();
        }
	}

    void initializeCards()
    {
        //Cycles through the values twice as each card has a match.
        for (int id = 0; id < 2; id++)
        {
            //values between 1 and 13.
            for (int i = 1; i < 14; i++)
            {
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<Card>().initialized);
                    //if initialized, test is now false, and will run through again.
                }
                cards[choice].GetComponent<Card>().cardValue = i;
                cards[choice].GetComponent<Card>().initialized = true;
            }
        }

        foreach(GameObject c in cards)
            c.GetComponent<Card>().setupGraphics();
        if (!_init)
            _init = true;
    }

     
    public Sprite getCardBack()
    {
        return cardBack;
    }

    public Sprite getCardFace(int i)
    {
        return cardFace[i - 1];
    }

    void checkCards()
    {
        List<int> c = new List<int>();

        for (int i = 0; i < cards.Length; i++)
        {
            //if a card is face up, add it to this list
            if (cards[i].GetComponent<Card>().state == 1)
            {
                c.Add(i);
            }
        }

        //if there are 2 face up cards compare them.
        if (c.Count == 2)
        {
            cardComparison(c);
        }
    }


    void cardComparison(List<int> c)
    {
        Card.DO_NOT = true;

        int x = 0;

        if (cards[c[0]].GetComponent<Card>().cardValue == cards[c[1]].GetComponent<Card>().cardValue)
        {
            x = 2;
            _matches--;
            matchText.text = "Number of matches: " + _matches;
            if (_matches == 0) //if game is won, load menu.
                SceneManager.LoadScene("room 1_redo");
        }

        for (int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().state = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }
    }

}
