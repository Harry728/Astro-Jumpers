using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    [Range(0, 15)]
    [SerializeField] float angle = 15f;
    [Range(0, 15)]
    [SerializeField] float speed = 10f;

    private Vector3 rotationAngles = Vector3.zero;

    void Start()
    {
        rotationAngles = new Vector3(Random.Range(-angle, angle), 
                                     Random.Range(-angle, angle),
                                     Random.Range(-angle, angle));
    }

    void Update()
    {
        transform.RotateAround(transform.position, rotationAngles, speed * Time.deltaTime);
    }
}
