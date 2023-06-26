using UnityEngine;

public class EnemyBigSumbarine : WeaponBase
{
    //[SerializeField] private float damageRange;
    [SerializeField] private LayerMask playerMask;

    [SerializeField] private float attackRange;

    private Transform nearestEnemy;
    private float nearestEnemyDistance;
    private float currentDistance;
    private Vector3 targetPosition;

    private Transform target;

    [SerializeField] protected float timeBetweenShots;
    protected float nextShotTime;


    private void Start()
    {
        bulletPrefab.GetComponent<HomingMissile>().Damage = damage;
    }
    private void Update()
    {
        SearchTarget();
    }

    private void SearchTarget()
    {
        nearestEnemy = null;
        nearestEnemyDistance = Mathf.Infinity;

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, attackRange, playerMask);
        foreach (Collider2D playerObject in hitObjects)
        {
            currentDistance = Vector2.Distance(transform.position, playerObject.GetComponent<Transform>().transform.position);

            if (currentDistance < nearestEnemyDistance)
            {
                nearestEnemy = playerObject.GetComponent<Transform>().transform;
                nearestEnemyDistance = currentDistance;
                Shoot();
            }
        }
    }

    public override void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            GameObject homingMissile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            homingMissile.GetComponent<HomingMissile>().SetTarget(nearestEnemy);
            nextShotTime = Time.time + timeBetweenShots;
        }
    }

    public void SetTarget(Transform transform)
    {
        target = transform;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(firePoint.position, attackRange);
    }
}