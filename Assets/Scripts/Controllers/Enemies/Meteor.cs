using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] GameObject explosion = null;

    void Awake()
    {
        Rotator rotator = gameObject.GetComponent<Rotator>();
        rotator.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bumper")) {
            if (explosion != null) {
                Vector3 point = other.ClosestPoint(transform.position);
                Instantiate (explosion, point, Quaternion.identity, null);
            }
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
