using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationTrigger : MonoBehaviour
{
        
    
    [SerializeField] private Information information;

    private void Start()
    {
        TriggerInformation();
    }
    public void TriggerInformation()
    {
        FindObjectOfType<InformationManager>().ShowInformation(information);
    }
}
