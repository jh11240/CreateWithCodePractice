using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public PlayerStat playerStat;
    private void OnTriggerEnter(Collider other)
    {
        //�÷��̾�� ����ϸ� �ȵǹǷ� �÷��̾� ����
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) return;

        //������ enemyStat ���۳�Ʈ ��������
        if(other.TryGetComponent<EnemyStat>(out EnemyStat enemyStat))
        {
            enemyStat.CurFed++;
        }

        //���ٱ� ����
        Destroy(gameObject);
    }
}
