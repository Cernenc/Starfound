using Assets.Script.Enemies.Interfaces;
using UnityEngine;

/// <summary>
/// reflects in opposite direction for now -> todo: vector math and stuff
/// </summary>
public class Reflector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var projectile = other.GetComponent<IEnemyProjectile>();
        if(projectile != null)
        {
            BounceProjectile(projectile);
        }
    }

    private void BounceProjectile(IEnemyProjectile projectile)
    {
        projectile.MoveDirection = -projectile.MoveDirection;
    }
}
