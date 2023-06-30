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
