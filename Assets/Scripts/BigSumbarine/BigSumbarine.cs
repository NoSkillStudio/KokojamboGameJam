using UnityEngine;

public class BigSumbarine : WeaponBase
{
    [SerializeField] private LayerMask enemyMask;

    [SerializeField] private Vector2 attackSize;
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
        Collider2D[] hitObjects = Physics2D.OverlapBoxAll(transform.position, attackSize, 0, enemyMask);
        foreach (var enemyObject in hitObjects)
        {
            enemyObject.gameObject.TryGetComponent(out Enemy enemy);
            enemy.DeactivateAiPath();
        }


        SearchTarget();

    }

    private void SearchTarget()
    {
        nearestEnemy = null;
        nearestEnemyDistance = Mathf.Infinity;

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyMask);
        foreach (Collider2D enemyObject in hitObjects)
        {
            currentDistance = Vector2.Distance(transform.position, enemyObject.GetComponent<Transform>().transform.position);

            if (currentDistance < nearestEnemyDistance)
            {
                nearestEnemy = enemyObject.GetComponent<Transform>().transform;
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
}