using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource sound;
    public UnityEvent Win;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode()
    {
        Win.Invoke();
        sound.Play();
        animator.SetTrigger("Explose");
    } 
}
