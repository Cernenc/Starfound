using UnityEngine;

namespace Assets.Script.Enemies.Interfaces
{
    public interface IEnemyProjectile
    {
        float LifeSpan { get; set; }

        void DestroyProjectile();

        Vector2 DirectionalPoint { get; set; }
    }
}
