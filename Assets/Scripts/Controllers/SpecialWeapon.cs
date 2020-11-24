using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeapon : MonoBehaviour
{
    enum ACTIONS {NONE, SPINUP, HOVER, LAUNCH};

    public GameObject prefab = null;
    [SerializeField] float spinUpDuration = 10f;
    [SerializeField] float hoverDuration = 3f;
    [SerializeField] float proximityTolerance = 0.1f;
    [SerializeField] float maxJudder = 0.1f;
    
    int siloIndex = -1;
    Silo silo = null;
    int action = -1;
    float timer = 0f;
    float actionTime = 0f;
    float distance = 0f;
    Vector3 hoverPosition = Vector3.zero;

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
            SpinUp();
        } else if (action == (int) ACTIONS.HOVER) {
            Hover();
        }
     }

    public void SetSiloIndex(int siloIndex, Silo silo)
    {
        this.siloIndex = siloIndex;
        this.silo = silo;
    }

    void SpinUp()
    {
        if (distance == 0f) {
            distance = Vector3.Distance(silo.hoverPoint.position,
                                        transform.position)
                                        / (spinUpDuration / Time.fixedDeltaTime);
        }
        transform.position = Vector3.MoveTowards(transform.position,
                                                   silo.hoverPoint.position,
                                                   distance);
        if (Mathf.Abs(Vector3.Distance(silo.hoverPoint.position, transform.position)) <= proximityTolerance) {
            action = (int) ACTIONS.HOVER;
            hoverPosition = transform.position;
        } 
    }

    void Hover()
    {
        transform.position = new Vector3(hoverPosition.x += Random.Range(-maxJudder, maxJudder),
                                         hoverPosition.y += Random.Range(-maxJudder, +maxJudder),
                                         hoverPosition.z += Random.Range(-maxJudder, +maxJudder));
    }
}
