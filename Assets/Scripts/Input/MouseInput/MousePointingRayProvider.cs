using UnityEngine;

public class MousePointingRayProvider
{
    private Camera camera;
    private IScreenPointProvider mousePointScreenPosProvider;
    public MousePointingRayProvider(Camera camera, IScreenPointProvider mousePointScreenPosProvider)
    {
        this.camera = camera;
        this.mousePointScreenPosProvider = mousePointScreenPosProvider;
    }

    public Ray GetRay()
    {
        Vector2 mousePointViewportPos = camera.ScreenToViewportPoint(mousePointScreenPosProvider.GetScreenPoint());
        Vector3 nearClipPlaneMousePointWorldPos = camera.ViewportToWorldPoint(new Vector3(
            mousePointViewportPos.x, mousePointViewportPos.y, camera.nearClipPlane));
        Vector3 farClipPlaneMousePointWorldPos = camera.ViewportToWorldPoint(new Vector3(
           mousePointViewportPos.x, mousePointViewportPos.y, camera.farClipPlane));
        Vector3 vectorToFarClipPlane = farClipPlaneMousePointWorldPos - nearClipPlaneMousePointWorldPos;
        return new Ray(nearClipPlaneMousePointWorldPos, vectorToFarClipPlane);
    }
}
