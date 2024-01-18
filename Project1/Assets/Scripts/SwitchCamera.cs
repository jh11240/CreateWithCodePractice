using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera Main;
    public Camera Driver;
    public bool isPlayer = true;
    private bool isMain=true;
    void Switching()
    {
        if (isMain)
        {
            Main.gameObject.SetActive(false);
            Driver.gameObject.SetActive(true);
            isMain = false;
        }
        else
        {
            Driver.gameObject.SetActive(false);
            Main.gameObject.SetActive(true);
            isMain = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer&&Input.GetKeyDown(KeyCode.P))
        {
            Switching();
        }
        else if(!isPlayer && Input.GetKeyDown(KeyCode.O))
        {
            Switching();
        }
    }
}
