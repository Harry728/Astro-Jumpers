using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [SerializeField] Transform target = null;
    [SerializeField] int damage = 100;

    Ground ground = null;

    private void Start()
    {
        if (target == null) {
            Debug.LogError("No target for moon");
            Destroy(gameObject);
        }
        GetComponent<Mover>().SetTarget(target);
        ground = GameObject.Find("Ground").GetComponent<Ground>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bumper") || other.name.Equals("Ground")) {
            ground.TakeDamage(damage);
        }
    }
}
