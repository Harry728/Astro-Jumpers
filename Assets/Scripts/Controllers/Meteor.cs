using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    void Awake()
    {
        Transform target = GameObject.FindWithTag("Player").transform;
        Rotator rotator = gameObject.GetComponent<Rotator>();
        rotator.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bumper")) {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Vector3 target)
    {
        Mover mover = gameObject.GetComponent<Mover>();
        mover.target = target;
        mover.enabled = true;
    }
}
