using System.Linq;
using UnityEngine;

public class EnemyFollowState : EnemyBaseState
{
    public Transform target;
    Vector2 movement;

    float directionX;
    float directionY;
    public float detectionRadius;

    public EnemyFollowState(Enemy enemy, Animator animator, Transform target, float followRadius) : base(enemy, animator)
    {
        this.target = target;
        detectionRadius = followRadius;
    }

    public void FollowToTarget()
    {
        
        Vector3 direction = target.position - enemy.transform.position;
        Ray2D ray = new Ray2D(enemy.transform.position, direction);
        float angle = Mathf.Atan2(direction.y, direction.x);
        directionX = Mathf.Cos(angle);
        directionY = Mathf.Sin(angle);
        Debug.DrawRay(enemy.transform.position, direction, Color.yellow);
        RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position, direction, 10, LayerMask.GetMask("SolidObjects"));

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
        }

        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position,
        target.position, enemy.speed * Time.deltaTime);


        animator.SetFloat("Horizontal", directionX);
        animator.SetFloat("Vertical", directionY);
        movement = new Vector2(directionX, directionY).normalized;
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    public override void OnEnter()
    {
        animator.CrossFade(WalkHash, crossFadeDuration);
    }

    public override void Update()
    {
        
    }

    public override void FixedUpdate()
    {
        FollowToTarget();
    }

    public override void OnExit()
    {
        animator.SetFloat("LastH", directionX);
        animator.SetFloat("LastV", directionY);
        animator.SetFloat("Speed", 0);
    }
}
