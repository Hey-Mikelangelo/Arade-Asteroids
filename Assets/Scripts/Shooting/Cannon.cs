using UnityEngine;

public abstract class Cannon : MonoBehaviour
{
    [SerializeField] private float cooldown;

    protected float cooldownTime => cooldown;
    public abstract void Fire();
}
