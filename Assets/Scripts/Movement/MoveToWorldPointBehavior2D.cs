using UnityEngine;

public class MoveToWorldPointBehavior2D : MonoBehaviour
{
    [SerializeField] private Mover2D mover2D;

    public void MoveToPoint(Vector2 targetPoint, Vector2? moveAxisConstraint = null)
    {
        Vector2 currentPosition = mover2D.GetCurrentPosition();
        Vector2 vectorToTargetPosition = MathUtils2D.GetVectorFromTo(currentPosition, targetPoint);
        if (moveAxisConstraint.HasValue)
        {
            vectorToTargetPosition = moveAxisConstraint.Value * Vector2.Dot(moveAxisConstraint.Value, vectorToTargetPosition);
        }
        mover2D.Move(vectorToTargetPosition, vectorToTargetPosition.magnitude);

    }
}
