using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] GameObject explosion = null;
    [SerializeField] int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Moon"))
        {
            if (explosion != null)
            {
                Vector3 point = other.ClosestPoint(transform.position);
                Instantiate(explosion, point, Quaternion.identity, null);
            }
            Moon moon = other.GetComponent<Moon>();
            if (moon != null) {
                moon.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}