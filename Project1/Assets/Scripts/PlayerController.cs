using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    private float forwardInput;
    private float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward*speed*Time.deltaTime*forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime*turnSpeed*horizontalInput);
    }
}
