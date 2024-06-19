using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public SmartMove enemyMove;
    public int attackRange;
    public GameObject attackBox;
    public Animator animator;
    public int damage = 2;

    private Rigidbody2D rb;
    private bool isAttacking = false; // Флаг для контроля выполнения атаки

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        if (!isAttacking && enemyMove.distanceToPlayer < attackRange)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;

        // Остановка перед рывком
        enemyMove.moveSpeed = 0;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.5f); // Полсекунды перед рывком

        // Рывок в сторону цели
        Vector2 attackDirection = ((Vector2)enemyMove.target.position - (Vector2)transform.position).normalized;
        rb.AddForce(attackDirection * 500); // Настройте силу рывка по вашему усмотрению

        // Полная остановка после рывка
        rb.velocity = Vector2.zero;

        // Атака
        attackBox.SetActive(true);
        attackBox.transform.position = transform.position + new Vector3(attackDirection.x, attackDirection.y, 0);
        animator.SetTrigger("IsAttack");
        yield return new WaitForSeconds(0.1f); // Время атаки

        // Остановка после атаки
        attackBox.SetActive(false);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1); // Задержка после атаки

        isAttacking = false;
        enemyMove.moveSpeed = 3;
    }
}
