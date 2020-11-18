using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaler : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] float speed = 1f;

    void Update()
    {
        transform.localScale *= 1 + (speed * Time.deltaTime);
    }
}
