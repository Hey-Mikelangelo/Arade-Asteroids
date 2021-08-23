using UnityEngine;

public class UfoSpawner : OutCameraViewSpawner
{
    [SerializeField] private Vector2 minMaxUfopeed;

    protected override void OnSpawned(GameObject instance)
    {
        Vector2 randomPointInsideCamRect = MathUtils2D.GetRandomPointInsideRect(cameraRectWorld);
        Vector2 directionToCameraRectPoint = MathUtils2D.GetVectorFromTo(instance.transform.position, randomPointInsideCamRect);
        float meteorSpeed = Random.Range(minMaxUfopeed.x, minMaxUfopeed.y);
        instance.GetComponent<Ufo>().SetVelocity(directionToCameraRectPoint.normalized * meteorSpeed);
    }
}


