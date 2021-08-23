using UnityEngine;


public class BulletCannon : Cannon
{
    [SerializeField] private SpawnedObjectType projectileType;
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private float bulletSpeed;

    private float cooldownTimeElapsed;
    private bool isCooledDown = true;
    private ThingPool projectileSpawner;

    private void Start()
    {
        projectileSpawner = Pool.Instance.GetPool(projectileType);
    }
    public override void Fire()
    {
        if (isCooledDown)
        {
            isCooledDown = false;
            cooldownTimeElapsed = 0;

            Projectile2D bullet = SpawnBullet();
            Vector2 shootDirection = shootOrigin.right;
            bullet.SetVelocity(shootDirection * bulletSpeed);
        }

    }

    private Projectile2D SpawnBullet()
    {
        Projectile2D bullet = projectileSpawner.GetInstance().GetComponent<Projectile2D>();
        Transform bulletTranform = bullet.transform;
        bulletTranform.position = shootOrigin.position;
        bulletTranform.rotation = shootOrigin.rotation;
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    private void Update()
    {
        HandleCooldown();
    }

    private void HandleCooldown()
    {
        if (isCooledDown)
        {
            return;
        }
        cooldownTimeElapsed += Time.deltaTime;
        if (cooldownTimeElapsed >= cooldownTime)
        {
            isCooledDown = true;
        }
    }
}
