using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void OnCollisionWithDamaging(Collision2D collision)
    {
        GameEvents.Instance.PlayerBulletCollidedWith(collision.gameObject);
        base.OnCollisionWithDamaging(collision);
    }
}

