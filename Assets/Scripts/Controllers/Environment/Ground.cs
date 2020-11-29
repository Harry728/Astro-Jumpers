using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] EarthOMeter earthOMeter = null;
    public Color fadeToColor = new Color(0, 0, 0, 0);

    Material groundMaterial;
    Color color;
    int maxHealth = 100;
    int health = 0;

    void Start()
    {
        health = maxHealth;
        groundMaterial = GetComponent<Renderer>().material;
        color = groundMaterial.color;
        FadeToColor();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        FadeToColor();
        if (health <= 0) {
            Debug.LogWarning("You FAILED, the Earth is dead");
        }
    }

    void FadeToColor()
    {
        float healthRatio = 1 - ((float) health / (float) maxHealth);
        Color newColor = Color.Lerp(color, fadeToColor, healthRatio);
        groundMaterial.color = newColor;
        earthOMeter.ApplyDamage(healthRatio);
    }
}
