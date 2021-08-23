using UnityEngine;
[ExecuteAlways]
public class ThingDestroyerOutOfCamera : MonoBehaviour
{
    [SerializeField] private AThing aThing;
    private Camera camera;
    private Rect cameraWorldExtendedRect;
    private void OnEnable()
    {
        camera = Camera.main;
        int extend = 5;
        cameraWorldExtendedRect = MathUtils2D.GetRectCameraWorld(camera).GetExpanded(extend, extend, extend, extend);
    }


    private void Update()
    {
        if (!cameraWorldExtendedRect.Contains(aThing.transform.position))
        {
            aThing.ForceDestroy();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(cameraWorldExtendedRect.center, cameraWorldExtendedRect.size);
    }
}
