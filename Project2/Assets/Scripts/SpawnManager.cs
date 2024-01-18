using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int animalIndex;
    //for left-right moving animals
    public float spawnRangeZ = 10.0f;
    public float spawnPosX = 22f;

    //for up-down moving animals
    public float spawnRangeX = 10.0f;
    private float spawnPosZ = 20.0f;

    private Vector3 horizontalSpawnVec;
    private Vector3 verticalSpawnVec;

    private float startDelay = 2;
    private float spawnInterval = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        //���� up-down spawning
        horizontalSpawnVec = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);


        //�״��� left-right spawning
        // 0���� 2���� ���� ������ 1�̻����� ����
        verticalSpawnVec = new Vector3(Random.Range(0, 2) >= 1 ? -spawnPosX : spawnPosX, 0, Random.Range(0, spawnRangeZ));
        animalIndex = Random.Range(0, animalPrefabs.Length);

        //spawning updown moving animals
        Instantiate(animalPrefabs[animalIndex], horizontalSpawnVec,
            animalPrefabs[animalIndex].transform.rotation);

        //spawning leftright moving animals
        //�����ų����� ��̾����� animalindex+1 �ε����� �ش��ϴ� ���� ��������
        //���� ������ ���� ���� rotation�����������.
        Instantiate(animalPrefabs[animalIndex + 1 >= animalPrefabs.Length ? animalIndex : animalIndex + 1], verticalSpawnVec,
            verticalSpawnVec.x > 0 ? Quaternion.Euler(0, 270f, 0) : Quaternion.Euler(0,90f,0));
    }
}
