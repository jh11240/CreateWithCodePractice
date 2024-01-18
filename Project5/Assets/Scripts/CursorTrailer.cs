using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTrailer : MonoBehaviour
{
    TrailRenderer trailRenderer;
    SphereCollider sphereCollider;

    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        sphereCollider = GetComponent<SphereCollider>();
        trailRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            trailRenderer.enabled = true;
            sphereCollider.enabled = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            trailRenderer.enabled = false;
            sphereCollider.enabled = false;
        }
    }
}
