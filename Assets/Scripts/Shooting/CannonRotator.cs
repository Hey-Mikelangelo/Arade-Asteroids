using UnityEngine;

public class CannonRotator : MonoBehaviour
{
    [SerializeField] private Transform cannonRotatableHead;
    [SerializeField] private Mover2D headMover;
    private Vector2? targetPosition;

    public void SetTarget(Vector2? targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    private void Update()
    {
        if(targetPosition == null)
        {
            return;
        }
        Vector2 origin = cannonRotatableHead.position;
        Quaternion targetRotation = MathUtils2D.GetRotationToPoint(origin, targetPosition.Value);

        headMover.Rotate(targetRotation);
    }
}
