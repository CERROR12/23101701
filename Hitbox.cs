using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [Tooltip("이 부위가 머리라면 체크하세요")]
    public bool isHead = false; 

    private EnemyTarget enemyTarget;

    void Start()
    {
        // 부모 오브젝트들 중에서 EnemyTarget 스크립트를 자동으로 찾아 연결
        enemyTarget = GetComponentInParent<EnemyTarget>();
    }

    // 총알이 닿았을 때 호출할 함수
    public void OnHit(int damage)
    {
        if (enemyTarget != null)
        {
            enemyTarget.TakeDamage(damage, isHead);
        }
    }
}