using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTFiring : MonoBehaviour
{
    [SerializeField] GameObject projectile = null;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float force = 50;
    [SerializeField] GameObject shellPrefab = null;
    [SerializeField] Transform[] ejectPoints;
    [SerializeField] float ejectForce = 1f;
    [SerializeField] bool dualMode = false;

    bool currentFiringMode = false;

    private void Update()
    {
        if (dualMode != currentFiringMode) {
            Animator animator = GetComponent<Animator>();
            if (animator == null) return;
            animator.SetBool("Fire", !dualMode);
            animator.SetBool("Dual Fire", dualMode);
        }
    }

    void Fire(int spawnIndex)
    {
        Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject bullet = Instantiate(projectile, spawnPoint.position, spawnPoint.transform.rotation, null);
        bullet.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * force, ForceMode.Impulse);
    }

    void DualFire()
    {
        Fire(0);
        Fire(1);
    }

    void EjectShell(int barrelIndex)
    {
        Transform ejectPoint = ejectPoints[barrelIndex];

        GameObject shell = Instantiate(shellPrefab, ejectPoint.position, ejectPoint.transform.rotation, null);
        shell.GetComponent<Rigidbody>().AddForce(ejectPoint.transform.forward * ejectForce,
                                                ForceMode.Impulse);

    }

    void DualEject()
    {
        EjectShell(0);
        EjectShell(1);
    }
}
