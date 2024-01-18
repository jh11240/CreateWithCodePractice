using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    } 

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            lookDirection = new Vector3(lookDirection.x, 0, lookDirection.z);
        enemyRb.AddForce( lookDirection* speed);
        }
        if(transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
