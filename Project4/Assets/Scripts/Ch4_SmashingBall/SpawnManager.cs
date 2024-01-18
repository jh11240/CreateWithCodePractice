using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // 적들 생성할 부모 오브젝트 트랜스폼
    public Transform Enemies;

    public GameObject[] enemyPrefabs;
    public GameObject bossPrefabs;
    public GameObject[] powerupPrefab;
    private float spawnRange = 9;
    public int enemyCount=1;
    public int waveNumber=1;
    public int bossWaveNum = 3;

    // Start is called before the first frame update
    void Start()
    {
        int itemIdx = Random.Range(0, powerupPrefab.Length);
        Instantiate(powerupPrefab[itemIdx], GenerateSpawnPosition(), powerupPrefab[itemIdx].transform.rotation);
        SpawnEnemyWave(waveNumber);
        StartCoroutine(CheckEnemy());
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        if (enemiesToSpawn % bossWaveNum == 0)
        {
            Instantiate(bossPrefabs, Vector3.up*2, Quaternion.identity,Enemies);
        }
        else
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                int randomEnemyIdx = Random.Range(0, enemyPrefabs.Length);
                Instantiate(enemyPrefabs[randomEnemyIdx], GenerateSpawnPosition(), enemyPrefabs[randomEnemyIdx].transform.rotation, Enemies);
            }
        }

    }
    public void SpawnItem()
    {
        int itemIdx = Random.Range(0, powerupPrefab.Length);
        Instantiate(powerupPrefab[itemIdx], GenerateSpawnPosition(), powerupPrefab[itemIdx].transform.rotation);
    }
    IEnumerator CheckEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            enemyCount = Enemies.childCount;

            if (enemyCount == 0)
            {
                waveNumber++;
                int itemIdx = Random.Range(0, powerupPrefab.Length);
                Instantiate(powerupPrefab[itemIdx], GenerateSpawnPosition(), powerupPrefab[itemIdx].transform.rotation);

                SpawnEnemyWave(waveNumber);
            }
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
