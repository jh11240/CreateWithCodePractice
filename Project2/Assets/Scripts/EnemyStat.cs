using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStat : MonoBehaviour
{
    //ÇÃ·¹ÀÌ¾î ½ºÅÈ
    public PlayerStat playerStat;
    //¸ÔÀÌ ÃÖ´ëÄ¡
    [SerializeField]private float fullFed = 3;
    //ÇöÀç ¸ÔÀº ¸ÔÀÌ
    [SerializeField]private float curFed = 0;

    //¹è°íÇÄ bar
    public Slider hungerBar;

    public float CurFed
    {
        get { return curFed; }
        set
        {
            curFed = value;
            if (fullFed <= curFed)
            {
                playerStat.Score++;
                hungerBar.value = 1;
                Destroy(gameObject);
            }
            hungerBar.value = CurFed / fullFed;
        }
    }
}
