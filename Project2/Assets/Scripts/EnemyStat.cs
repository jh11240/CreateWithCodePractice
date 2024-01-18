using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStat : MonoBehaviour
{
    //�÷��̾� ����
    public PlayerStat playerStat;
    //���� �ִ�ġ
    [SerializeField]private float fullFed = 3;
    //���� ���� ����
    [SerializeField]private float curFed = 0;

    //����� bar
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
