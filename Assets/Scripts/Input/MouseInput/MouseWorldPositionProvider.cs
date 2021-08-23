using UnityEngine;

public class MouseWorldPositionProvider : IWorldPointProvider
{
    private Camera camera;
    private IScreenPointProvider mouseScreenPositionProvider;
    public MouseWorldPositionProvider(Camera camera, IScreenPointProvider mouseScreenPositionProvider)
    {
        this.camera = camera;
        this.mouseScreenPositionProvider = mouseScreenPositionProvider;
    }
    
    public Vector3 GetWorldPoint()
    {
        Vector2 mouseScreenPosition = mouseScreenPositionProvider.GetScreenPoint();
        return camera.ScreenToWorldPoint(mouseScreenPosition);
    }
}
