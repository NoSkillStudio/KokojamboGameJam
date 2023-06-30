using UnityEngine;

public class Rocket : MonoBehaviour
{
	[SerializeField] protected float speed;
    protected Rigidbody2D rb;

    public int Damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(Damage);
        }
        Destroy(gameObject);
    }
}