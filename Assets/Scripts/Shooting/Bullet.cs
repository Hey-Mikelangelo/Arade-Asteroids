using UnityEngine;

public abstract class Bullet : Projectile2D
{
    protected override void OnCollisionWithDamaging(Collision2D collision)
    {
        Destroy();
    }
}

