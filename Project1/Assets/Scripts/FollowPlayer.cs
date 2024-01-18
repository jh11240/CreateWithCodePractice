using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;

    void LateUpdate()
    {
        transform.position = Player.transform.position+new Vector3(0,6,-10);
    }
}
