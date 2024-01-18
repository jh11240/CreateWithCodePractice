using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegatePrac : MonoBehaviour
{
    public DelegateGameOver delegateGameOver;
    //public delegate bool Compare(int a,int b);

    //public void Practice(Compare @new,int arg,int arg2)
    //{
    //    if (@new(arg, arg2))
    //        Debug.Log("arg is bigger");
    //    else
    //        Debug.Log("arg2 is bigger");
    //}

    private void OnEnable()
    {
        
        DelegateGameOver.action += actionPrac;
    }
    public void damaged(float dmg)
    {
        Debug.Log(dmg);
    }
    public void echo(string shout)
    {
        Debug.Log(shout);
    }
    public void shout() 
    {
        Debug.Log("AHHHHH!!!");
    }
    void actionPrac(int a, int b, float c, string d)
    {
        Debug.Log(a+" "+b +" "+c+" "+d);
    }
    void DenyGameOver()
    {
        Debug.Log("게임은 끝나지 않았다.");
    }
    void AcceptGameOver()
    {
        Debug.Log("게임은 끝났어.");
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //DelegateGameOver.onGameOver?.Invoke();
        }
    }

    private void OnDisable()
    {

    }
}
