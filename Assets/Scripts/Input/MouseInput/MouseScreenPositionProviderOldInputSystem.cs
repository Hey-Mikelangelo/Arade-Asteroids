using UnityEngine;

public class MouseScreenPositionProviderOldInputSystem : IScreenPointProvider
{
    public Vector3 GetScreenPoint()
    {
        return Input.mousePosition;
    }
}
