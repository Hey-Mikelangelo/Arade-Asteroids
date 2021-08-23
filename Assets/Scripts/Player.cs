using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask damagingLayers;
    [SerializeField] private MoveToWorldPointBehavior2D moveToWorldPointBehavior;
    [SerializeField] private RotateToPointBehavior2D rotateToPointBehavior2D;
    [SerializeField] private Cannon mainCannon;

    private IWorldPointProvider mouseWorldPointProvider;
    private Cannon activeCannon;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Awake()
    {
        IScreenPointProvider mouseScreenPointProvider = new MouseScreenPositionProviderOldInputSystem();
        mouseWorldPointProvider = new MouseWorldPositionProvider(mainCamera, mouseScreenPointProvider);
        activeCannon = mainCannon;

        GameEvents.onGameStart += GameEvents_onGameStart;
        GameEvents.onGameOver += GameEvents_onGameOver;
    }

    private void GameEvents_onGameStart()
    {
        transform.position = Vector3.zero;
        gameObject.SetActive(true);

    }
    private void GameEvents_onGameOver()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        Vector2 mouseWorldPoint = mouseWorldPointProvider.GetWorldPoint();
        if (Input.GetKey(KeyCode.Space))
        {
            //move space-craft   
            moveToWorldPointBehavior.MoveToPoint(mouseWorldPoint, transform.right);
        }
        rotateToPointBehavior2D.RotateToPoint(mouseWorldPoint);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Shoot
            activeCannon.Fire();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (damagingLayers.Contains(collisionGameObject.layer))
        {
            GameEvents.Instance.PlayerCollidedWith(collisionGameObject);
        }
    }
}
