using Assets.Script.Enemies.Interfaces;
using UnityEngine;

public class Reflector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var projectile = other.GetComponent<IEnemyProjectile>();
        if(projectile != null)
        {
             projectile.DestroyProjectile();
        }
    }
}
