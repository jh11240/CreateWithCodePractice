using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Fire", menuName = "Pattern/Fire")]
public class Fire : Pattern
{
    public GameObject bossBullet;
    private GameObject tmpBullet;
    Vector3[] dirs = { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };
    public override void ExecutePattern(Transform player, Transform boss, Transform Enemies)
    {
        for(int i = 0; i < 4; i++)
        {
            tmpBullet = Instantiate(bossBullet, boss.transform.position + dirs[i] * 2, Quaternion.identity);
            tmpBullet.GetComponent<BossBullet>().dir =  dirs[i];
        }
    }
}
