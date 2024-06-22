using UnityEngine;

[RequireComponent(typeof(TargetDetector))]
public class Enemy : Entity
{
    public Animator animator;

    public GameObject attackBox;

    public float followRange;
    public float attackRange;

    public TargetDetector targetDetector;

    public Transform target;

    public float timeBetweenAttacks = 1f;

    public bool isAttacking;

    StateMachine stateMachine;

    private void Awake()
    {
        targetDetector = new() { detectionRadius = followRange, innerDetectionRadius = attackRange};
    }

    private void Start()
    {
        stateMachine = new StateMachine();
        var enemyFollow = new EnemyFollowState(this, animator, target, followRange);
        var idleFollow = new EnemyIdleState(this, animator);
        var attackFollow = new EnemyDashAttackState(this, animator, target, timeBetweenAttacks);

        At(idleFollow, enemyFollow, new FuncPredicate(() => targetDetector.CanFollow(target, transform)));
        At(enemyFollow, idleFollow, new FuncPredicate(() => !targetDetector.CanFollow(target, transform)));
        At(enemyFollow, attackFollow, new FuncPredicate(() => targetDetector.CanAttack(target, transform)));
        At(attackFollow, enemyFollow, new FuncPredicate(() => !targetDetector.CanAttack(target, transform) && !isAttacking));


        stateMachine.SetState(idleFollow);
    }

    void At(IState from, IState to, IPredicate condition) => stateMachine.AddTransition(from, to, condition);

    void Any(IState to, IPredicate condition) => stateMachine.AddAnyTransition(to, condition);



    void Update()
    {
        stateMachine.Update();
    }

    void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

}
