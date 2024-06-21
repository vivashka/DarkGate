using UnityEngine;

public class SmartMove : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public DashAttack enemyAttack;

    public Transform target;

    public float detectionRadius = 2f;
    public Animator animator;
    Vector2 movement;

    float directionX;
    float directionY;
    public float distanceToTarget;

    public void FollowToTarget()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x);
        directionX = Mathf.Cos(angle);
        directionY = Mathf.Sin(angle);
        Debug.DrawRay(transform.position, direction, Color.yellow);

        transform.position = Vector2.MoveTowards(transform.position,
        target.position, moveSpeed * Time.deltaTime);

        animator.SetFloat("Horizontal", directionX);
        animator.SetFloat("Vertical", directionY);
        movement = new Vector2(directionX, directionY).normalized;
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
