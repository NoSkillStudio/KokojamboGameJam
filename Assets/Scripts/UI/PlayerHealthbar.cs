using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
	[SerializeField] private UnitHealth player;
	private Image image;
	private void Start()
	{
		image = GetComponent<Image>();	
	}

	private void Update()
	{
        image.fillAmount = player.Health / player.MaxHealth;		
    }
}