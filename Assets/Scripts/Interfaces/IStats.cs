public interface IStats
{
    float Mana { get; set; }
    float ManaToAdd { get; set; }
    bool CanUsePower { get; set; }
    float MaxMana { get; set; }
    float Strength { get; set; }
    void AddMana(float manaToAdd);
}
