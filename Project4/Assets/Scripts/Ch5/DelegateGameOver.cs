using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
[Serializable]
public class FloatEvent : UnityEvent<float> { }
[Serializable]
public class StringEvent : UnityEvent<String> { }

public class DelegateGameOver : MonoBehaviour
{
    //public delegate void GameOver();
    //public static event GameOver onGameOver;

    //public UnityEvent onGameOver;
    //public FloatEvent onDamaged;
    //public StringEvent echo;
    public GameEvent onGameOver;

    public static event Action<int, int, float, string> action;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onGameOver.TriggerEvent();
            action?.Invoke(3, 4, 0.5f, "action ±â°¡¸·Èù´Ù~");
        }
    }
}
