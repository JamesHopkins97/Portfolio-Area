using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualityOfShot : MonoBehaviour
{

    private ScoreManager Score;
    public Text QualityOfPicture;

    public Image Green4KImage;
    public Image YellowFullHDImage;
    public Image Amber480Image;
    public Image Red144Image;

	// Use this for initialization
	void Start ()
    {
        Score = GameObject.Find("GameManager").GetComponent<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Not here?

        float percentage = (((float)Score.score / (float)Score.maxScore) * 100);
        QualityOfPicture.text = Score.score + "/" + Score.maxScore + " | " + percentage.ToString("n0") + "%";
        ShowTheBanner();

    }


    int GetTheScore()
    {
        int CurrentScore = 0;

        CurrentScore = Score.score;
        return CurrentScore;
    }


    public void ShowTheBanner()
    {

        int score;
        score = GetTheScore();

        if (score <= Score.maxScore * 0.25)
        {
            Red144Image.enabled = true;
            Green4KImage.enabled = false;
            YellowFullHDImage.enabled = false;
            Amber480Image.enabled = false;

        }

       else if (score <= Score.maxScore * 0.5 && score > Score.maxScore * 0.25)
        {
            Red144Image.enabled = false;
            Amber480Image.enabled = true;
            YellowFullHDImage.enabled = false;
            Green4KImage.enabled = false;
        }

        else if (score <= Score.maxScore * 0.75 && score > Score.maxScore * 0.5)
        {
            Red144Image.enabled = false;
            Amber480Image.enabled = false;
            YellowFullHDImage.enabled = true;
            Green4KImage.enabled = false;
        }

        else if ( score > Score.maxScore * 0.75)
        {
            Red144Image.enabled = false;
            Amber480Image.enabled = false;
            YellowFullHDImage.enabled = false;
            Green4KImage.enabled = true;
        }

    }
}
