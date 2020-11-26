using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Range (0, 100)]
    [SerializeField] float speed = 1f;
    [Range (0, 100)]
    [SerializeField] float minSpeed = 1f;
    [SerializeField] AnimationCurve speedFalloff;

    public Vector3 target;

    float totalDistanceToTarget = 0f;

    private void Awake()
    {
        if (minSpeed > 0) {
            speed = Random.Range(speed, minSpeed);
        }
    }

    void Update()
    {
        if (totalDistanceToTarget == 0f) {
            totalDistanceToTarget = Mathf.Abs(Vector3.Distance(transform.position, target));
        }
        float distanceToTarget = Mathf.Abs(Vector3.Distance(transform.position, target));
        float damper = speedFalloff.Evaluate(distanceToTarget / totalDistanceToTarget);
        transform.position =
            Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime * damper);
    }

    public void SetTarget(Transform target)
    {
        this.target = target.position;
    }
}
