using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

public class EnemyGun : WeaponBase
{
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private AIDestinationSetter aI;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource shootSound;

    [SerializeField] protected float timeBetweenShots;
    protected float nextShotTime;

    private Transform nearestEnemy;
    private float nearestEnemyDistance;
    private float currentDistance;
    private Vector3 targetPosition;

    [SerializeField] private UnityEvent OnShot;
    private void Start()
    {

    }

    private void Update()
    {
        SearchTarget();
        Rotate();
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
            }
        }
    }

    private void Rotate()
    {
        if (Time.time > nextShotTime)
        {
            if (nearestEnemy != null)
            {
                targetPosition = nearestEnemy.transform.position;
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x) * Mathf.Rad2Deg);
                OnShot.Invoke();
                animator.SetTrigger("Shoot");
                nextShotTime = Time.time + timeBetweenShots;
            }

            //if (targetPosition.x < 0)
            //{
            //    aI.Rotate(targetPosition);
            //    if (transform.rotation.eulerAngles.y == 180)
            //        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180f /* изменить!!! */, Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x) * Mathf.Rad2Deg);
            //    else transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x) * Mathf.Rad2Deg);
            //    transform.localScale = new Vector3(1f, -1f, 1f);
            //}
            //else if (targetPosition.x > 0)
            //{
            //    player.Rotate(targetPosition);
            //    if (transform.rotation.eulerAngles.y == 180f)
            //        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 180f, Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x) * Mathf.Rad2Deg);
            //    else transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x) * Mathf.Rad2Deg);
            //    transform.localScale = new Vector3(1f, 1f, 1f);
            //}

        }
    }

    public override void Shoot()
    {
        shootSound.Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}


