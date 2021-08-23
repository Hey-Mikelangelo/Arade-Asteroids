using UnityEngine;

public class Ufo : Projectile2D
{
    [SerializeField] private Cannon mainCannon;
    [SerializeField] private CannonRotator cannonRotator;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private float detectionRadius;
    private Collider2D[] collidersInRadius;
    
    protected override void Awake()
    {
        base.Awake();
        collidersInRadius = new Collider2D[20];
    }

    protected override void Update()
    {
        base.Update();
        Vector2 origin = transform.position;
        float radius = detectionRadius;
        if(Physics2D.OverlapCircleNonAlloc(origin, radius, collidersInRadius, playerLayerMask.value) > 0)
        {
            Vector3 playerPos = collidersInRadius[0].transform.position;
            cannonRotator.SetTarget(playerPos);
            mainCannon.Fire();
        }
        else
        {
            cannonRotator.SetTarget(null);
        }
    }

    protected override void OnCollisionWithDamaging(Collision2D collision)
    {
        Destroy();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
