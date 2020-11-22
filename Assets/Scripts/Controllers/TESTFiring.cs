using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTFiring : MonoBehaviour
{
    [SerializeField] GameObject projectile = null;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float force = 50;

    void FireLeft()
    {
        GameObject bullet = Instantiate(projectile, spawnPoint.position, projectile.transform.rotation, null);
        bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * force, ForceMode.Impulse);
    }
}
