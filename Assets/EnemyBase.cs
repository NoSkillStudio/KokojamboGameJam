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

    public void Explode()
    {
        Win.Invoke();
        sound.Play();
        animator.SetTrigger("Explose");
    } 
}
