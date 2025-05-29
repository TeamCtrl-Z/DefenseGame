public interface IBuffStatus
{
    public float AttackSpeedFactor { get; }
    public float AttackPowerFactor { get; }

    public void BuffStatus(BuffType type, float amount);
    public void BuffStop(BuffType type);
}