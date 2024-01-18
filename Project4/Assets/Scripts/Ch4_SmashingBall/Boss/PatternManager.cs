using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    public Pattern[] patterns;
    public Transform Enemies;
    public GameObject player;
    public SpawnManager spawnManager;

    private void Awake()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        player = GameObject.Find("Player");
        Enemies = GameObject.Find("Enemies").GetComponent<Transform>();
        StartCoroutine(DoPattern());
    }

    private IEnumerator DoPattern()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            if (player == null) yield break;
            int idx = Random.Range(0, patterns.Length);
            patterns[idx].ExecutePattern(player.transform, transform, Enemies);
            spawnManager.SpawnItem();
            yield return new WaitForSeconds(3f);
        }
    }
}
