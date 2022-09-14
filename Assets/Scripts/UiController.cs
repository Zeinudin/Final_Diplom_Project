using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public Text scoresDisplay;
    public Text HighScore;
    public static float score;
    int highscore;
    public int HealtPlayer;
    public Slider SliderHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.scoreEvent += ScoreChange;
        
        // Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        score = 0;
        HighScore.text = "Рекорд: " + PlayerPrefs.GetInt("scores").ToString();
       
    }

    // Update is called once per frame
    void ScoreChange(int scores)
    {
        highscore = (int)scores;
        scoresDisplay.text = "Очки: " + highscore.ToString();
        if (PlayerPrefs.GetInt("scores") <= highscore)
            PlayerPrefs.SetInt("scores", highscore);
        HighScore.text = "Рекорд: " + PlayerPrefs.GetInt("scores").ToString();
        /*if (scoresDisplay != null)
           scoresDisplay.text = scores.ToString();*/
        /*if (scores > highscore)
        {
            highscore = scores;
            PlayerPrefs.SetInt("Text(1):", highscore);
            PlayerPrefs.Save();
        }*/
    }

    private void Update()
    {
        SliderHealth.value = HealtPlayer;


    }


    void OnDestroy()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;

    }

    internal void MakeDamage(int v)
    {
        HealtPlayer -= v;
    }
}
