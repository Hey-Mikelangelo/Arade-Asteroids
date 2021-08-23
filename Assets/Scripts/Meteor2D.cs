using UnityEngine;

public class Meteor2D : Projectile2D
{
    [SerializeField] private bool doFracure = false;
    [SerializeField] private SpawnedObjectType fracturedPieceType;
    [SerializeField] private int fracturedPiecesCount = 2;

    private ThingPool fracturedPiecesPool;
    private bool isPrevFractureShootRight;

    protected override void OnCollisionWithDamaging(Collision2D collision)
    {
        if (doFracure)
        {
            Fracture();
        }
        Destroy();
    }

    private void Start()
    {
        fracturedPiecesPool = Pool.Instance.GetPool(fracturedPieceType);
    }

    private void Fracture()
    {
        for(int i = 0; i < fracturedPiecesCount; i++)
        {
            GameObject piece = fracturedPiecesPool.GetInstance();
            piece.transform.position = gameObject.transform.position;
            Meteor2D pieceMeteor = piece.GetComponent<Meteor2D>();
            Vector2 pieceVelocity = GetFracturePieceRandomVelocity(mover2D.LastMovementVector);
            pieceMeteor.SetVelocity(pieceVelocity);
        }

    }

    private Vector2 GetFracturePieceRandomVelocity(Vector2 asteroidVelocity)
    {
        isPrevFractureShootRight = !isPrevFractureShootRight;
        float asteroidvelocitySideAddMagnitude = Random.Range(0, 10);
        Vector2 asteroidVeclocitySideDir = Vector3.Cross(asteroidVelocity, Vector3.forward).normalized;
        Vector2 astroidvelocitySideAdd = (asteroidVeclocitySideDir * (asteroidvelocitySideAddMagnitude));
        int sideVelocitySign = isPrevFractureShootRight ? 1 : -1;
        Vector2 fracturePieceVelocity = asteroidVelocity + (sideVelocitySign * astroidvelocitySideAdd);
        fracturePieceVelocity.Normalize();
        fracturePieceVelocity *= asteroidVelocity.magnitude * 1.5f;
        Debug.DrawRay(gameObject.transform.position, fracturePieceVelocity, Color.green, 2);

        return fracturePieceVelocity;
    }

}
