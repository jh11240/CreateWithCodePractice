using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBarFollowingObject : MonoBehaviour
{
    public GameObject objectToFollow;
    private RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    private void LateUpdate()
    {
        rect.position = Camera.main.WorldToScreenPoint(objectToFollow.transform.position+Vector3.forward);
    }
}
