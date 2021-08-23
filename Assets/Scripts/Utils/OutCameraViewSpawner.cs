using UnityEngine;

public abstract class OutCameraViewSpawner : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float cameraOutsideExpandRect;
    [SerializeField] private float cameraInsideExpandRect;
    [SerializeField] private SpawnedObjectType spawnedObjectType;
    [SerializeField] private float spawnInterval;

    private Timer timer;
    private ThingPool spawnedObjectsPool;
    protected Rect cameraRectWorld { get; private set; }

    protected abstract void OnSpawned(GameObject instance);

    private void Awake()
    {
        timer = new Timer(this);
        GameEvents.onGameStart += GameEvents_onGameStart;
        GameEvents.onGameOver += GameEvents_onGameOver;
        GameEvents_onGameOver();

    }

    protected virtual void OnEnable()
    {
        timer.OnTimerCycle += Timer_OnTimerCycle;
        timer.Reset();
        timer.SetCycleTime(spawnInterval);
        timer.Start();
    }

    protected virtual void OnDisable()
    {
        timer.OnTimerCycle -= Timer_OnTimerCycle;
        timer.Stop();
    }

    private void GameEvents_onGameStart()
    {
        enabled = true;
    }
    private void GameEvents_onGameOver()
    {
        enabled = false;
    }

    private void Start()
    {
        spawnedObjectsPool = Pool.Instance.GetPool(spawnedObjectType);
    }

    private void Timer_OnTimerCycle()
    {
        GameObject instance = SpawnObject();
        instance.transform.position = GetValidPosition();
        OnSpawned(instance);
    }

    private Vector3 GetValidPosition()
    {
        Rect cameraWorldRect = MathUtils2D.GetRectCameraWorld(playerCamera);
        this.cameraRectWorld = cameraWorldRect; 
        float e1 = cameraInsideExpandRect;
        Rect insideSpawnRect = cameraWorldRect.GetExpanded(e1, e1, e1, e1);
        float e2 = cameraOutsideExpandRect;
        Rect outsideSpawnRect = cameraWorldRect.GetExpanded(e2, e2, e2, e2);
        return MathUtils2D.GetRandomPointBetweenRects(insideSpawnRect, outsideSpawnRect);
    }

    private GameObject SpawnObject()
    {
        GameObject instance = spawnedObjectsPool.GetInstance();
        return instance;
    }

    private void OnDrawGizmos()
    {
        if (playerCamera == null)
        {
            return;
        }
        Rect cameraWorldRect = MathUtils2D.GetRectCameraWorld(playerCamera);
        float e1 = cameraInsideExpandRect;
        Rect insideSpawnRect = cameraWorldRect.GetExpanded(e1, e1, e1, e1);
        float e2 = cameraOutsideExpandRect;
        Rect outsideSpawnRect = cameraWorldRect.GetExpanded(e2, e2, e2, e2);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(insideSpawnRect.center, insideSpawnRect.size);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(outsideSpawnRect.center, outsideSpawnRect.size);
    }

}


