using UnityEngine;

public class ThingPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int initialInstances; 

    private PrefabPool prefabPool;

    private void Awake()
    {
        prefabPool = new PrefabPool(prefab, initialInstances);
    }
    public GameObject GetInstance()
    {
        IPoolable poolable = prefabPool.GetInstance();
        GameObject poolableGO = poolable.GetGameObject();
        poolableGO.transform.parent = transform;
        return poolableGO;
    }
}
