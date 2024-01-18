using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundary : MonoBehaviour
{
    private float topBound = 30f;
    private float leftBound = 30f;
    private float bottomBound = -10f;
    public PlayerStat playerStat;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < bottomBound)
        {
            playerStat.Lives--;
            Destroy(gameObject);
        }

        if(transform.position.x > leftBound)
        {
            Destroy(gameObject);
        }
        if(transform.position.x < -leftBound)
        {
            Destroy(gameObject);
        }
    }
}
