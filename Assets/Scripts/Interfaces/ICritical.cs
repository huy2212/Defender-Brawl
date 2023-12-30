public interface ICritical
{
    float CriticalHitChance { get; set; }
    float CriticalHitMultiplier { get; set; }
    bool IsCritical();
}