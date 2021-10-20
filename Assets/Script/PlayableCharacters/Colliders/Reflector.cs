using Assets.Script.Enemies.Interfaces;
using UnityEngine;

public class Reflector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var projectile = collision.gameObject.GetComponent<IEnemyProjectile>();
        if (projectile != null)
        {
            ContactPoint contact = collision.GetContact(0);
            BounceProjectile(projectile, contact);
        }
    }

    private void BounceProjectile(IEnemyProjectile projectile, ContactPoint contact)
    {
        Debug.Log(projectile.DirectionalPoint);
        projectile.DirectionalPoint = Vector3.Reflect(projectile.Direction.normalized, contact.point.normalized);
        Debug.Log(projectile.DirectionalPoint);

    }
}
