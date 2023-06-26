using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private LayerMask enemyHomingMissileMask;
    [SerializeField]
    private LayerMask submarineMask;
    [SerializeField] private bool canExplose = false;

    [SerializeField] private float bulletStunTime;
    [SerializeField] private float rocketStunTime;

    [SerializeField] private UnityEvent OnStunned;
    [SerializeField] private UnityEvent OnNormal;
    [SerializeField] private UnityEvent OnFindPlayer;
    [SerializeField] private UnityEvent OnCollideEnemybase;

    private void Update()
	{
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, range, enemyHomingMissileMask);
        foreach (var rocket in hitObjects)
        {
            rocket.gameObject.TryGetComponent(out HomingMissile homingMissile);
            if(homingMissile != null)
            homingMissile.DeactivateHomingMissile();
        }

        Collider2D[] hitObjects1 = Physics2D.OverlapCircleAll(transform.position, range, submarineMask);
        foreach (var rocket in hitObjects1)
        {
            OnFindPlayer.Invoke();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            Stan(bulletStunTime);
        }
        if (collision.gameObject.TryGetComponent(out HomingMissile missile))
        {
            Stan(rocketStunTime);
        }

        if (collision.gameObject.TryGetComponent(out EnemyBase enemyBase) && canExplose)
        {
            OnCollideEnemybase.Invoke();
        }
    }

    private void Stan(float stunTime)
    {
        OnStunned.Invoke();
        Invoke("SetNormal", stunTime);
    }

    private void SetNormal() => OnNormal.Invoke();

    public void ActiveCanExplose() => canExplose = true;
}