using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerStat",menuName = "Stat")]
public class PlayerStat : ScriptableObject
{
    [SerializeField]
    private int score;
    [SerializeField]
    private int lives;

    private void OnEnable()
    {
        score = 0;
        lives = 3;
        Debug.Log("Lives = " + lives + " Score : " + score);
    }

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            Debug.Log("Score = " + score);
        }
    }
    public int Lives
    {
        get
        { 
            return lives; 
        }
        set
        {
            if (value == 0)
            {
                Debug.Log("Game Over!");
            }
            lives = value;
            Debug.Log("Lives = "+lives);
        }
    }
}
