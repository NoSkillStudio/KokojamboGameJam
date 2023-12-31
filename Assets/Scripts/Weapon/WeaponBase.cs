using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected GameObject bulletPrefab;

    [SerializeField] protected int damage;

    public abstract void Shoot();
}