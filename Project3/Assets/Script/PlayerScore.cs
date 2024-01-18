using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score=0;
    PlayerController playerControllerScript;
    private float count=0;

    private void Awake()
    {
        playerControllerScript = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameStart) return;
        count += Time.deltaTime;
        //fastmode면 두 배로 증가
        if (playerControllerScript.FastMode)
        {
            count += Time.deltaTime;
        }
        if (count > 1 && !playerControllerScript.gameOver)
        {
            Debug.Log(++score);
            count = 0;
        }
    }
}
