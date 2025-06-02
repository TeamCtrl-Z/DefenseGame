public class EnemyDieState : EnemyBaseState
{
    public EnemyDieState(EnemyStateMachine stateMachine) : base(stateMachine)
    { }

    public override void Enter(EnemyController sender)
    {
        base.Enter(sender);
        //stateMachine.Animator.SetTrigger("Die");
        sender.Die();
    }
}