using UnityEngine;

public class SimpleMover2D : Mover2D
{
    private Transform movedTransform;

    private void Awake()
    {
        movedTransform = transform;
    }

    protected override void MoveTowards(Vector2 movementVector)
    {
        movedTransform.position += (Vector3)movementVector * Time.deltaTime;
    }

    public override Vector2 GetCurrentPosition()
    {
        return movedTransform.position;
    }

    protected override void RotateTowards(Quaternion targetRotation)
    {
        Quaternion currentRotation = movedTransform.rotation;
        Quaternion newRotation = Quaternion.RotateTowards(currentRotation, targetRotation, RotationSpeed * Time.deltaTime);
        movedTransform.rotation = newRotation;
    }
}
