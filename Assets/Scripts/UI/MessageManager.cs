using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void Show(string message)
    {
        text.text = message;
    }

    public void Hide()
    {
        text.text = "";
    }
}