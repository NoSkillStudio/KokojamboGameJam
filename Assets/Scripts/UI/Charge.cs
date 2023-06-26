using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Charge : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    private Image image;

    [SerializeField] protected float timeBetweenShots;
    protected float nextShotTime;
    private int index;

    [SerializeField] private UnityEvent OnEndCharge;

    private void Start()
    {
        image = GetComponent<Image>();
        index = 0;
        image.sprite = sprites[index];
        nextShotTime = timeBetweenShots;
    }
    private void Update()
    {
        if (Time.time > nextShotTime)
        {
            if (index == 2)
            {
                OnEndCharge.Invoke();
            }
                index++;
            image.sprite = sprites[index];

            nextShotTime = Time.time + timeBetweenShots;
        }
    }

    public void UpCharge()
    {
        if (index == 0)
            return;
        index--;
        image.sprite = sprites[index];
    }
}
