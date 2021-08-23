using UnityEngine;

public abstract class AThing : MonoBehaviour, IPoolable
{
    private PrefabPool parentPool;

    protected virtual void Awake()
    {
        OnSpawn();
    }


    protected virtual void OnEnable()
    {
        GameEvents.onGameStart += GameEvents_onGameStart;
        GameEvents.onGameOver += GameEvents_onGameOver;
    }

    protected virtual void OnDisable()
    {
        GameEvents.onGameStart -= GameEvents_onGameStart;
        GameEvents.onGameOver -= GameEvents_onGameOver;
    }

    private void GameEvents_onGameStart()
    {
    }
    private void GameEvents_onGameOver()
    {
        ForceDestroy();
    }

    public void ForceDestroy()
    {
        Destroy();
    }

    protected void Destroy()
    {
        if (parentPool != null)
        {
            ReturnToPool();
        }
        else
        {
            BeforeDestroy();
            Destroy(gameObject);
        }
    }

    protected virtual void OnSpawn()
    {
        gameObject.SetActive(true);
    }

    protected virtual void BeforeDestroy()
    {
        gameObject.SetActive(false);

    }

    private void ReturnToPool()
    {
        parentPool.ReturnObject(this);
    }

    public void OnSpawnFromPool()
    {
        OnSpawn();
    }

    public void BeforeReturnToPool()
    {
        BeforeDestroy();
    }

    public void SetParentPool(PrefabPool pool)
    {
        parentPool = pool;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
