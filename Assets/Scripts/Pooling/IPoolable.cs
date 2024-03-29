﻿public interface IPoolable
{
    /// <summary>
    /// The system expects the IPoolable implementation to know which pool spawned it, so cache the reference to it.
    /// </summary>
    void SetParentPool(PrefabPool pool);
    /// <summary>
    /// Prepare the entire game object for being pooled
    /// </summary>
    void BeforeReturnToPool();
    /// <summary>
    /// Prepare the game object for spawn, in essence just reset it into an initial state.
    /// </summary>
    void OnSpawnFromPool();
    UnityEngine.GameObject GetGameObject();
}
