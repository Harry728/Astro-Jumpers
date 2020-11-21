using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Range (0, 100)]
    [SerializeField] float speed = 1f;
    [Range (0, 100)]
    [SerializeField] float minSpeed = 1f;

    public Vector3 target;

    private void Awake()
    {
        if (minSpeed > 0) {
            speed = Random.Range(speed, minSpeed);
        }
    }

    void Update()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
