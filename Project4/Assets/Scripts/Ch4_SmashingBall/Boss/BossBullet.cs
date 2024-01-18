using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public Vector3 dir;
    public float speed;
    public float powerupStrength = 6.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            //normalized ¾ÈÇØµµµÊ
            playerRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
