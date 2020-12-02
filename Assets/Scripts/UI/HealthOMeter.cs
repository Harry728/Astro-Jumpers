using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthOMeter : MonoBehaviour
{
    Image ometerImage = null;

    private void Awake() 
    {
        ometerImage = GetComponent<Image>();
    }

    public void ApplyDamage(float healthRatio)
    {
        ometerImage.fillAmount = 1 - healthRatio;
    }
}
