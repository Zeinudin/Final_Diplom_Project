using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager 
{
    private int _userScores = 0;
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameManager();
            return _instance;
        }
    }
    private GameManager() { }
    public delegate void EventScoreHandler(int scores);
    public event EventScoreHandler scoreEvent = delegate { };

    public void deadunit(GameObject unit)
    {
        switch (unit.tag)
        {
            case "Player":
                    gameOver();
                break;
            case "Enemy":
                _userScores += 100;
                scoreEvent(_userScores);
                break;
           
        }    
    }


    private void gameOver()
    {
        _userScores = 0;
        scoreEvent = delegate { };
        SceneManager.LoadScene(0);
    }

}
