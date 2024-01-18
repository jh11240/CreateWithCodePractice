using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public PlayerStat playerStat;
    private void OnTriggerEnter(Collider other)
    {
        //플레이어랑 닿게하면 안되므로 플레이어 무시
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) return;

        //적에게 enemyStat 컴퍼넌트 가져오기
        if(other.TryGetComponent<EnemyStat>(out EnemyStat enemyStat))
        {
            enemyStat.CurFed++;
        }

        //뼈다귀 삭제
        Destroy(gameObject);
    }
}
