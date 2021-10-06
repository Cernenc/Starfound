namespace Assets.Script.Enemies.Interfaces
{
    public interface IEnemyAttributeManager
    {
        float Speed { get; set; }
        float Damage { get; set; }
        float ProjectileDamage { get; }
        float ProjectileInbetweenCooldown { get; }
    }
}
