using UnityEngine;

public abstract class Mover2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0;
    [SerializeField, Tooltip("angles per sec")] private float rotationSpeed = 0;

    public float MoveSpeed => moveSpeed;
    public float RotationSpeed => rotationSpeed;
    public Vector2 LastMovementVector { get; private set; }

    public void Move(Vector2 moveDirection, float maxDistanceThisFrame = float.MaxValue)
    {
        float speedVectorMagnitude = Mathf.Clamp(MoveSpeed, 0, maxDistanceThisFrame / Time.deltaTime);
        Vector2 movementVector = moveDirection.normalized * speedVectorMagnitude;
        MoveTowards(movementVector);
        LastMovementVector = movementVector;
    }
    public void Rotate(Quaternion targetRotation)
    {
        RotateTowards(targetRotation);
    }

    public void SetMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }

    public void SetRotationSpeed(float newRotationSpeed)
    {
        rotationSpeed = newRotationSpeed;
    }

    public abstract Vector2 GetCurrentPosition();

    protected abstract void MoveTowards(Vector2 movementVector);
    protected abstract void RotateTowards(Quaternion newRotation);

}

