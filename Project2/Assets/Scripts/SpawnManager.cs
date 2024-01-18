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
        //기존 up-down spawning
        horizontalSpawnVec = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);


        //그다음 left-right spawning
        // 0부터 2까지 랜덤 돌려서 1이상으로 잡음
        verticalSpawnVec = new Vector3(Random.Range(0, 2) >= 1 ? -spawnPosX : spawnPosX, 0, Random.Range(0, spawnRangeZ));
        animalIndex = Random.Range(0, animalPrefabs.Length);

        //spawning updown moving animals
        Instantiate(animalPrefabs[animalIndex], horizontalSpawnVec,
            animalPrefabs[animalIndex].transform.rotation);

        //spawning leftright moving animals
        //같은거나오면 재미없으니 animalindex+1 인덱스에 해당하는 동물 내보내기
        //왼쪽 오른쪽 각도 따라서 rotation변경해줘야함.
        Instantiate(animalPrefabs[animalIndex + 1 >= animalPrefabs.Length ? animalIndex : animalIndex + 1], verticalSpawnVec,
            verticalSpawnVec.x > 0 ? Quaternion.Euler(0, 270f, 0) : Quaternion.Euler(0,90f,0));
    }
}
