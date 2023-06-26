using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChipCounterText : MonoBehaviour
{
	[SerializeField] private TMP_Text pichCountText;

	public void ShowValue(int value)
	{ 
		pichCountText.text = "0" + value.ToString();

		if(value == 10)
            pichCountText.text = value.ToString();
    }
}