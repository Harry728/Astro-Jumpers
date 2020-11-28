using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] GameObject explosion = null;
    [SerializeField] int damage = 1;

    Spawner spawner = null;
    Ground ground = null;

    void Awake()
    {
        Rotator rotator = gameObject.GetComponent<Rotator>();
        rotator.enabled = true;
    }

    private void Start() 
    {
        ground = GameObject.Find("Ground").GetComponent<Ground>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bumper") || other.tag.Equals("Bullet")) {
            if (explosion != null) {
                Vector3 point = other.ClosestPoint(transform.position);
                Instantiate (explosion, point, Quaternion.identity, null);
            }
            spawner.ClearSpawned(this);
            Destroy(gameObject);
            if (other.tag.Equals("Bullet")) {
                Destroy(other.gameObject);
            } else {
                ground.TakeDamage(damage);
            }
        }
    }

    public void SetTarget(Vector3 target, Spawner spawner)
    {
        Mover mover = gameObject.GetComponent<Mover>();
        mover.target = target;
        mover.enabled = true;
        this.spawner = spawner;
    }
}
