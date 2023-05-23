public interface IDamageable<T>
{
    void InDamage(T damageVariable);
    int OutDamage { get; set;}
}

public interface IKillable
{
    void Kill();
}

public interface ICreature
{
    int Heath { get; set; }
    int MaxHeath { get; set; }
}
