using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : UnitHealth
{
    [SerializeField] private UnityEvent OnDie;
    [SerializeField] private AudioSource exploseSound;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override void Die()
    {
        base.Die();
        exploseSound.Play();
        OnDie?.Invoke();
        _animator.SetTrigger("Explose");
    }

    public void Explose()
    { 
        Destroy(gameObject);  
    }
}