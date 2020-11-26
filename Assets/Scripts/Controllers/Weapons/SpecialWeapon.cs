using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeapon : MonoBehaviour
{
    enum ACTIONS {NONE, SPINUP, HOVER, ARC, FACETARGET, LAUNCH};

    public GameObject prefab = null;
    [SerializeField] float spinUpDuration = 10f;
    [SerializeField] float hoverDuration = 3f;
    [SerializeField] float arcDuration = 2f;
    [SerializeField] float faceTargetSpeed = 5f;
    [SerializeField] float launchDuration = 0.5f;
    [SerializeField] float proximityTolerance = 0.1f;
    [SerializeField] float faceAngleTolerance = 30f;
    [SerializeField] float maxJudder = 0.1f;
    
    int siloIndex = -1;
    Silo silo = null;
    int action = -1;
    float timer = 0f;
    float actionTime = 0f;
    float distance = 0f;
    //float angularDistance = 0f;
    Vector3 hoverPosition = Vector3.zero;
    Transform target;

    private void Start() 
    {
        action = (int) ACTIONS.SPINUP;
        actionTime = spinUpDuration;
        target = GameObject.FindWithTag("Moon").transform;
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
        } else if (action == (int) ACTIONS.ARC) {
            Arc();
        } else if (action == (int) ACTIONS.FACETARGET) {
            FaceTarget();
        } else if (action == (int) ACTIONS.LAUNCH) {
            Launch();
        }
     }

    public void SetSiloIndex(int siloIndex, Silo silo)
    {
        this.siloIndex = siloIndex;
        this.silo = silo;
    }

    void SpinUp()
    {
        if (MoveMissile(silo.hoverPoint, spinUpDuration)) {
            action = (int) ACTIONS.HOVER;
            hoverPosition = transform.position;
            timer = 0f;
        }
    }

    void Hover()
    {
        if (timer >= hoverDuration) {
            action = (int) ACTIONS.ARC;
            distance = 0f;
            return;
        }
        transform.position = new Vector3(hoverPosition.x += Random.Range(-maxJudder, maxJudder),
                                         hoverPosition.y += Random.Range(-maxJudder, +maxJudder),
                                         hoverPosition.z += Random.Range(-maxJudder, +maxJudder));
    }

    void Arc()
    {
        if (MoveMissile(silo.arcPoint, arcDuration)) {
            action = (int) ACTIONS.FACETARGET;
            distance = 0f;
            //angularDistance = Vector3.Angle(transform.position, target.position);
        }
    }

    void FaceTarget()
    {
        float angle = Vector3.Angle(transform.forward, target.position - transform.position);
        if (angle <= faceAngleTolerance) {
            action = (int) ACTIONS.LAUNCH;
            distance = 0f;
            return;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation,
                                                Quaternion.LookRotation(target.position),
                                                Time.deltaTime * faceTargetSpeed);
    }

    void Launch()
    {
        MoveMissile(target, launchDuration);
        transform.LookAt(target.position);
    }

    bool MoveMissile(Transform targetTransform, float duration)
    {
        if (distance == 0f) {
            distance = Vector3.Distance(targetTransform.position,
                                        transform.position)
                                        / (duration / Time.fixedDeltaTime);
        }
        transform.position = Vector3.MoveTowards(transform.position,
                                                   targetTransform.position,
                                                   distance);
        if (Mathf.Abs(Vector3.Distance(targetTransform.position, transform.position)) <= proximityTolerance) {
            return true;
        } 
        return false;
    }
}
