using UnityEngine;

[System.Serializable]
public class Information
{
    [SerializeField] internal string name;

    [TextArea(3, 10)]
    [SerializeField] internal string[] sentences;
}