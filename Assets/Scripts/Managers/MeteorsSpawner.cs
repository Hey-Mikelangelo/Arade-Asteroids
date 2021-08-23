using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorsSpawner : OutCameraViewSpawner
{
    [SerializeField] private Vector2 minMaxMeteorSpeed;

    protected override void OnSpawned(GameObject instance)
    {
        Vector2 randomPointInsideCamRect = MathUtils2D.GetRandomPointInsideRect(cameraRectWorld);
        Vector2 directionToCameraRectPoint = MathUtils2D.GetVectorFromTo(instance.transform.position, randomPointInsideCamRect);
        float meteorSpeed = Random.Range(minMaxMeteorSpeed.x, minMaxMeteorSpeed.y);
        instance.GetComponent<Meteor2D>().SetVelocity(directionToCameraRectPoint.normalized * meteorSpeed);
    }    
}
