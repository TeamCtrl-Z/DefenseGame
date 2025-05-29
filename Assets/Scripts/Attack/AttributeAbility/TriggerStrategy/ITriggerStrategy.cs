/// <summary>
/// 발동 조건 전략
/// </summary>
public interface ITriggerStrategy
{
    void Initialize(BasicAttack basicAttack, AttackHandler handler, IAbilityEffect effect);

    void CleanUp(BasicAttack basicAttack, AttackHandler handler);
}