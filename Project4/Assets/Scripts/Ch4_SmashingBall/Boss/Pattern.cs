using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pattern : ScriptableObject
{
    public abstract void ExecutePattern(Transform player, Transform boss, Transform Enemies);

}
