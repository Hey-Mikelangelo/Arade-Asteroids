using UnityEngine;

public abstract class Projectile2D : AThing
{
    [SerializeField] protected Mover2D mover2D;
    [SerializeField] private LayerMask damagingLayers;
    protected Vector2 moveDirection;

    public void SetVelocity(Vector2 newVelocity)
    {
        float moveSpeed = newVelocity.magnitude;
        moveDirection = newVelocity.normalized; 
        mover2D.SetMoveSpeed(moveSpeed);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (damagingLayers.Contains(collisionGameObject.layer))
        {
            OnCollisionWithDamaging(collision);
        }
    }

    protected virtual void Update()
    {
        mover2D.Move(moveDirection);
    }

    protected abstract void OnCollisionWithDamaging(Collision2D collision);
}
