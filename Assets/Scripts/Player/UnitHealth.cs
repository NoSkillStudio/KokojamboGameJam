using UnityEngine;


public class UnitHealth : MonoBehaviour, IDamageable
{
    public int MaxHealth { get => maxHealth; }
    [SerializeField] private int maxHealth;

    public float Health { get => health; }
    private float health;

    private bool alive = true;

    private Animator _animator;

    private void Start()
    {
        health = maxHealth;
        _animator = GetComponent<Animator>();
    }

    public void ApplyDamage(int damageValue)
    {
        health -= damageValue;
        if (alive && health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        alive = false;
        _animator.SetTrigger("Explose");
    }

    public void Delete() => Destroy(gameObject);
}
