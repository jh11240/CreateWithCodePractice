using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppingUp : MonoBehaviour
{
    public float HoppingPower;
    public float CollideArea;
    public float pushAwayForce=4.0f;
    public float gravityStrength=3.0f;
    private bool isJumping=false;
    private Rigidbody rigidBody;
    private float distanceBetween;
    private Vector3 pushAwayDir;

    private void Awake()
    {
        rigidBody=GetComponent<Rigidbody>();
    }
    public void Hop()
    {
        isJumping = true;
        rigidBody.AddForce(Vector3.up*HoppingPower,ForceMode.Impulse);
        Physics.gravity += Vector3.down*gravityStrength;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isJumping) return;
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            Physics.gravity -= Vector3.down * gravityStrength;
            Collider[] enemies = Physics.OverlapSphere(transform.position, CollideArea);
            foreach(Collider enemy in enemies)
            {
                if (enemy.gameObject.CompareTag("Enemy"))
                {
                    distanceBetween = Vector3.Distance(transform.position,enemy.transform.position);
                     pushAwayDir= (enemy.transform.position - transform.position).normalized;
                    //거리에 반비례해서 던지기
                    enemy.GetComponent<Rigidbody>().AddForce((pushAwayDir + Vector3.up )*pushAwayForce*((float)1/distanceBetween),ForceMode.Impulse);
                }
            }
        }
    }
}
