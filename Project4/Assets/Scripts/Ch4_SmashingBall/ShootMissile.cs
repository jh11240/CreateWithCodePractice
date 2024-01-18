using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMissile : MonoBehaviour
{
    public GameObject missilePrefab;
    private GameObject bullet;
    public Transform enemiesParent;
    public Enemy[] enemies;
    public void Shoot()
    {
        enemies = enemiesParent.GetComponentsInChildren<Enemy>();
        foreach(Enemy enemy in enemies)
        {
            Vector3 enemyDir = (enemy.transform.position - transform.position).normalized;
            bullet=Instantiate(missilePrefab, transform.position + enemyDir*1.5f,Quaternion.identity);
            bullet.GetComponent<Bullet>().target = enemy.gameObject;
        }
    }
}
