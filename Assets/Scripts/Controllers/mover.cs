using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    [SerializeField] Transform target = null;
    [Range (0, 1)]
    [SerializeField] float speed = 1f;

    void Update()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
