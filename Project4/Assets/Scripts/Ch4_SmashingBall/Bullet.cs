using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public float knockOutStrength = 5f;
    public void Update()
    {
        if (target != null) 
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);

        else Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            //normalized ¾ÈÇØµµµÊ
            playerRigidbody.AddForce(awayFromPlayer * knockOutStrength, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
