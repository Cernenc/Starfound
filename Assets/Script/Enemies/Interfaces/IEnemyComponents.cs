using UnityEngine;

namespace Assets.Script.Enemies.Interfaces
{
    public interface IEnemyComponents
    {
        Transform Transform { get; }
        Collider Collider { get; }
    }
}
