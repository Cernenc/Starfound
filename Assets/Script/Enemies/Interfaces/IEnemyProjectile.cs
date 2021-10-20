using UnityEngine;

namespace Assets.Script.Enemies.Interfaces
{
    public interface IEnemyProjectile
    {
        float LifeSpan { get; set; }

        void DestroyProjectile();

        Vector3 Direction { get; set; }
        Vector2 DirectionalPoint { get; set; }
    }
}
