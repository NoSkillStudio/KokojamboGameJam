using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private LayerMask homingMissileMask;

    private RocketGun rocketGun;

    private SpriteRenderer spriteRenderer;

    private AIPath aiPath;
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        aiPath = GetComponent<AIPath>();

        rocketGun = FindObjectOfType<RocketGun>();
    }

    void Update()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, range, homingMissileMask);
        foreach (var rocket in hitObjects)
        {
            rocket.gameObject.TryGetComponent(out HomingMissile homingMissile);
            homingMissile.DeactivateHomingMissile();
        }

        spriteRenderer.flipX = aiPath.desiredVelocity.x <= 0.01f;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void DeactivateAiPath() => aiPath.canMove = false;
    public void ActivateAiPath() => aiPath.canMove = true;

    private void OnMouseDown()
    {
        rocketGun.SetTarget(transform);
        Debug.Log("asdfghj");
    }

}
