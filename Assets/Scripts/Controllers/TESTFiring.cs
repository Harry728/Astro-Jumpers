using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTFiring : MonoBehaviour
{
    [SerializeField] GameObject projectile = null;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float force = 50;

    void Fire(int spawnIndex)
    {
        Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject bullet = Instantiate(projectile, spawnPoint.position, spawnPoint.transform.rotation, null);
        bullet.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * force, ForceMode.Impulse);
    }
}
