using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    [SerializeField] private LayerMask meteorLayerMask;
    [SerializeField] private LayerMask ufoLayerMask;
    [SerializeField] private LayerMask ufoBulletLayerMask;
    [SerializeField] private UnityEvent OnGameOver;
    public static GameEvents Instance { get; private set; }

    private const string tagBig = "Big";
    private const string tagMedium = "Medium";

    public static event System.Action onPlayerCollidedWithBigMeteor;
    public static event System.Action onPlayerCollidedWithMediumMeteor;
    public static event System.Action onPlayerCollidedWithUfo;
    public static event System.Action onPlayerCollidedWithUfoBullet;

    public static event System.Action onPlayerBulletCollidedWithUfo;
    public static event System.Action onPlayerBulletCollidedWithBigMeteor;
    public static event System.Action onPlayerBulletCollidedWithMediumMeteor;
    public static event System.Action onGameOver;
    public static event System.Action onGameStart;


    private void Awake()
    {
        Instance = this;
    }

    public void PlayerCollidedWith(GameObject collisionGO)
    {
        if (meteorLayerMask.Contains(collisionGO.layer))
        {
            if (collisionGO.tag == tagBig)
            {
                onPlayerCollidedWithBigMeteor?.Invoke();
            }
            else if (collisionGO.tag == tagMedium)
            {
                onPlayerCollidedWithMediumMeteor?.Invoke();
            }
        }
        else if (ufoLayerMask.Contains(collisionGO.layer)){
            onPlayerCollidedWithUfo?.Invoke();
        }
        else if (ufoBulletLayerMask.Contains(collisionGO.layer))
        {
            Debug.Log("Collision");

            onPlayerCollidedWithUfoBullet?.Invoke();
        }
    }

    public void PlayerBulletCollidedWith(GameObject collisionGO)
    {
        if (meteorLayerMask.Contains(collisionGO.layer))
        {
            if (collisionGO.tag == tagBig)
            {
                onPlayerBulletCollidedWithBigMeteor?.Invoke();
            }
            else if (collisionGO.tag == tagMedium)
            {
                onPlayerBulletCollidedWithMediumMeteor?.Invoke();
            }
        }
        else if (ufoLayerMask.Contains(gameObject.layer))
        {
            onPlayerBulletCollidedWithUfo?.Invoke();
        }
    }

    public void GameOver()
    {
        Debug.Log("gameover");
        onGameOver?.Invoke();
        OnGameOver.Invoke();
    }

    public void StartGame()
    {
        Debug.Log("StartGame");
        onGameStart?.Invoke();
    }
}
