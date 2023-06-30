using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public Transform target = null;
    private Vector3 targetPosition;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    public int Damage;

    private Rigidbody2D rb;

    [SerializeField] private float offset;

    [SerializeField] private AudioSource explosionSound;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            Destroy(gameObject);
            Debug.Log("������ ����");
        }

        if (target != null)
        {
            targetPosition = new Vector3(Random.Range(target.transform.position.x - offset, target.transform.position.x + offset),
            Random.Range(target.transform.position.y - offset, target.transform.position.y + offset), target.transform.position.z);
        }

;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }

    }

    void OnTriggerEnter2D()
    {
        // Put a particle effect here
        Destroy(gameObject);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.TryGetComponent(out EnemyHealth enemy))
    //    {
    //        enemy.ApplyDamage(Damage);
    //    }
    //    Destroy(gameObject);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            explosionSound.Play();
            damageable.ApplyDamage(Damage);
        }
        Destroy(gameObject);
    }

    public void DeactivateHomingMissile() => rotateSpeed = 0;

    public void SetTarget(Transform transform)
    {
        target = transform;
    }
}