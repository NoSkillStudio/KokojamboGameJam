using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : UnitHealth
{
    [SerializeField] private Animator animator;
    [SerializeField] private UnityEvent OnDie;
    [SerializeField] private AudioSource exploseSound;
    public override void Die()
    {
        base.Die();
        exploseSound.Play();
        OnDie.Invoke();
        animator.SetTrigger("Explose");
    }

    public void Explose()
    { 
        Destroy(gameObject);  
    }
}