using UnityEngine;

public class CameraBordersTeleporter : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private Rect cameraWorldRect;

    private void Start()
    {
        cameraWorldRect = MathUtils2D.GetRectCameraWorld(mainCamera);
    }

    private void Update()
    {
        Vector3 position = transform.position;

        if (position.x < cameraWorldRect.xMin)
        {
            position.x = cameraWorldRect.xMax;
        }
        else if (position.x > cameraWorldRect.xMax)
        {
            position.x = cameraWorldRect.xMin;
        }

        if (position.y < cameraWorldRect.yMin)
        {
            position.y = cameraWorldRect.yMax;
        }
        else if (position.y > cameraWorldRect.yMax)
        {
            position.y = cameraWorldRect.yMin;
        }

        transform.position = position;
    }
}
