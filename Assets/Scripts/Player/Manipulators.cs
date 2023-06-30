using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Manipulators : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private LayerMask chipMask;
    [SerializeField] private Animator animator;

    [SerializeField] private UnityEvent OnReady;
    [SerializeField] private UnityEvent OnEnd;

    private bool canUp = false;
    void Update()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, range, chipMask);
        foreach (var chip in hitObjects)
        {
                animator.SetTrigger("Show");
        }

        
        if(canUp == true && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Work");
        }
            
    }

    public void ActivateUp() => canUp = true;
    public void DeactivateUp() => canUp = false;
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void GetReady() => OnReady.Invoke();
    public void GetEnd() => OnEnd.Invoke();
}