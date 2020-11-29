using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EarthOMeter : MonoBehaviour
{
    Image earthImage = null;

    private void Start() 
    {
        earthImage = GetComponent<Image>();
    }

    public void ApplyDamage(float healthRatio)
    {
        earthImage.fillAmount = 1 - healthRatio;
    }
}
