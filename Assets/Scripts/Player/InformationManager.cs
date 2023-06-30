using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class InformationManager : MonoBehaviour
{
    [SerializeField] private TMP_Text informationText;
    private Queue<string> sentenses;
    private int numberOfLetters = 0;
    [SerializeField] private float timeBetweenLetters;
    public int lettersInSentence;

    [SerializeField] private UnityEvent EndWriting;

    public UnityEvent NewLine;
    void Start()
    {
        sentenses = new Queue<string>();
    }

    public void ShowInformation(Information information)
    {
        sentenses.Clear();

        foreach (string sentence in information.sentences)
        {
            sentenses.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentenses.Count == 0)
        {
            HideInformation();
            return;
        }

        string sentence = sentenses.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentense(sentence));
    }

    IEnumerator TypeSentense(string sentence)
    {
        informationText.text = "";


        foreach (char letter in sentence.ToCharArray())
        {
            if (timeBetweenLetters <= 0.0001f)
            {
                informationText.text = "";
                informationText.text = sentence;
                yield return new WaitForSeconds(timeBetweenLetters);
            }
            else
            {
                numberOfLetters++;
                informationText.text += letter;
                if (numberOfLetters >= lettersInSentence)
                {
                    numberOfLetters = 0;
                    NewLine.Invoke();
                }
                yield return new WaitForSeconds(timeBetweenLetters);
            }

        }
        EndWriting.Invoke();
    }

    public void HideInformation()
    {
        StopAllCoroutines();
        informationText.text = "";
    }

    public void SetWritingSpeed(float value) => timeBetweenLetters = value;
    private void InvokeEndWriting() => EndWriting.Invoke();
}
