using UnityEngine;
using UnityEngine.Events;

public class ChipCollector : MonoBehaviour
{
    [SerializeField] private int maxChips = 10;
    private int chips;

    [SerializeField] private UnityEvent<int> PichCountChanged;
    [SerializeField] private UnityEvent OnMax;

    private void OnEnable()
    {
        Chip.OnPick += Chip_OnPick;
    }

    private void OnDisable()
    {
        Chip.OnPick -= Chip_OnPick;
    }

    private void Chip_OnPick()
    {
        chips++;
        if (chips == maxChips)
        {
            OnMax.Invoke();
        }
        else
        {
            PichCountChanged.Invoke(chips);
        }
    }
}