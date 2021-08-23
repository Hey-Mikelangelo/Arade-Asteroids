using UnityEngine;

public class RotateToPointBehavior2D : MonoBehaviour
{
    [SerializeField] private Mover2D mover2D;

    public void RotateToPoint(Vector2 targetPoint)
    {
        Vector2 currentPosition = mover2D.GetCurrentPosition();
        mover2D.Rotate(MathUtils2D.GetRotationToPoint(currentPosition, targetPoint));
    }
}
