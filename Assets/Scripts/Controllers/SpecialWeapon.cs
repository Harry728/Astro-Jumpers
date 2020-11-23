using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeapon : MonoBehaviour
{
    enum ACTIONS {NONE, SPINUP, HOVER, LAUNCH};

    public GameObject prefab = null;
    public float spinUpDuration = 10f;
    public float hoverDuration = 3f;
    
    int siloIndex = -1;
    Silo silo = null;
    int action = -1;
    float timer = 0f;
    float actionTime = 0f;

    private void Start() 
    {
        action = (int) ACTIONS.SPINUP;
        actionTime = spinUpDuration;
    }

    private void FixedUpdate() 
    {
        if (action == (int) ACTIONS.NONE) {
            return;
        }
        timer += Time.deltaTime;
        if (action == (int) ACTIONS.SPINUP) {
            //SpinUp();
        }
     }

    public void SetSiloIndex(int siloIndex, Silo silo)
    {
        this.siloIndex = siloIndex;
        this.silo = silo;
    }
/*
    void SpinUp()
    {
        transform.position = transform.position.MoveTowards(transform.position,
                                                            silo.hoverPoint.position,
                                                            Vector3.Distance(silo.hoverPoint.position,
                                                                transform.position)
                                                            / (spinUpDuration / Time.fixedDeltaTime));
    }
*/
}
