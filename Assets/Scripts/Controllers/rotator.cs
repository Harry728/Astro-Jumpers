using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Range(0, 45)]
    [SerializeField] float angle = 15f;
    [Range(0, 50)]
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
        transform.Rotate(rotationAngles.x, rotationAngles.y, rotationAngles.z, Space.Self);
    }
}
