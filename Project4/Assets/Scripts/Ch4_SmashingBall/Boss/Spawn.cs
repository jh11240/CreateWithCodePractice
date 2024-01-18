using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawn",menuName = "Pattern/Spawn")]
public class Spawn : Pattern
{
    public GameObject[] enemiesToSpawn;
    public Transform Enemies;

    public override void ExecutePattern(Transform player, Transform boss,Transform parentEnemies)
    {
        int idx = Random.Range(0, enemiesToSpawn.Length);
        Instantiate(enemiesToSpawn[idx],boss.transform.position+Vector3.forward*3 ,Quaternion.identity,parentEnemies);
        Instantiate(enemiesToSpawn[idx+1==enemiesToSpawn.Length ? 0:idx+1 ],boss.transform.position+Vector3.back*3 ,Quaternion.identity,parentEnemies);

    }

}
