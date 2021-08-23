using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private List<TypePool> typesSpawners = new List<TypePool>();
        
    public static Pool Instance { get; private set; }

    public ThingPool GetPool(SpawnedObjectType spawnedObjectType)
    {
        TypePool typesSpawner;
        for (int i = 0; i < typesSpawners.Count; i++)
        {
            typesSpawner = typesSpawners[i];
            if (typesSpawner.type == spawnedObjectType)
            {
                return typesSpawner.spawner;
            }
        }
        return null;
    }

    private void Awake()
    {
        Instance = this;   
    }

}
