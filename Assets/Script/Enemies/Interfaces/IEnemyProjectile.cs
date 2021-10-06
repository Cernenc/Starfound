namespace Assets.Script.Enemies.Interfaces
{
    public interface IEnemyProjectile
    {
        float LifeSpan { get; set; }

        void DestroyProjectile();
    }
}
