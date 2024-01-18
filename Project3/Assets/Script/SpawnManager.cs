using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController playerControllerScript;

    private float startDelay=2;
    private float repeatRate=2;

    private void Awake()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.gameStart) return;
        if(playerControllerScript.gameOver == false)
        {
            int idx = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[idx], spawnPos, obstaclePrefab[idx].transform.rotation);
        }
    }

}
