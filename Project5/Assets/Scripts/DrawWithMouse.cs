using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWithMouse : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 previousPosition;

    [SerializeField]
    private float minDistance = 0.1f;
    [SerializeField]
    private float width = 0.1f;

    private bool isDrawn = false;
    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1;
        line.startWidth = line.endWidth = width;
        previousPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0f;

            if (Vector3.Distance(currentPosition, previousPosition) > minDistance)
            {
                //first point
                if (previousPosition == transform.position)
                {
                    Debug.Log(line.positionCount);
                    line.SetPosition(0, currentPosition);
                }
                else
                {
                    isDrawn = true;
                    line.positionCount++;
                    line.SetPosition(line.positionCount - 1, currentPosition);
                }
                previousPosition = currentPosition;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            this.enabled = false;
        }
    }
    private void OnDisable()
    {
        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        Mesh mesh = new Mesh();
        line.BakeMesh(mesh, Camera.main, false);
        meshCollider.sharedMesh = mesh;
    }
}
