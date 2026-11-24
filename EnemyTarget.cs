using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [Header("체력 설정")]
    public int maxHealth = 2; // 기본 체력 2칸
    private int currentHealth;

    [Header("좌우 이동 설정")]
    public float moveSpeed = 3f;    // 이동 속도
    public float moveDistance = 4f; // 좌우 왕복 거리
    private Vector3 startPos;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        startPos = transform.position; // 시작 위치 저장
    }

    void Update()
    {
        if (isDead) return;

        // 시작 위치를 기준으로 X축(양옆) 왕복 이동
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2) - moveDistance;
        transform.position = startPos + new Vector3(offset, 0, 0);
    }

    // 피격 처리 함수 (Hitbox에서 호출)
    public void TakeDamage(int damage, bool isHeadshot)
    {
        if (isDead) return;

        if (isHeadshot)
        {
            Debug.Log("헤드샷! 즉사!");
            currentHealth = 0;
        }
        else
        {
            currentHealth -= damage;
            Debug.Log($"몸통 피격! 남은 체력: {currentHealth}");
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("적군 쓰러짐!");

        // 1. 쓰러지는 연출 (뒤로 90도 눕히기)
        // 나중에 쓰러지는 애니메이션이 있다면 animator.SetTrigger("Die")로 교체하세요.
        transform.rotation = Quaternion.Euler(-90f, transform.eulerAngles.y, 0f);

        // 2. 2초 뒤에 오브젝트 삭제 (원하지 않으면 아래 줄 주석 처리)
        Destroy(gameObject, 2f);
    }
}