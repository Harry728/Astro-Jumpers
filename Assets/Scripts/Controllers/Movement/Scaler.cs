using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] float speed = 1f;
    [SerializeField] bool maintainScale;

    Vector3 originalScale = Vector3.zero;

    private void Awake() 
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (maintainScale == true) {
            transform.localScale = originalScale;
        }
        transform.localScale *= 1 + (speed * Time.deltaTime);
    }
}
