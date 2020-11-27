using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] Transform pivot = null;
    [SerializeField] Animator animator = null;
    [Range(1, 10)]
    [SerializeField] float animatorSpeed = 1f;

    int controlsLayerMask = 1 << 8;

    private void Start()
    {
        if (animator != null) {
            animator.speed = animatorSpeed;
        }
    }

    void Update()
    {
        Follow();
        //FireCannon();
    }

    void Follow()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Casts the ray and checks for hit on Controls layer (invisible plane in front of the screen)
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, controlsLayerMask)) {
            //Debug.LogWarning("Hit " + hit.transform.name);
            pivot.LookAt(hit.point);
        }

        //transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    void FireCannon()
    {
        if (pivot == null) {
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Casts the ray and get the first game object hit
        //Physics.Raycast(ray, out hit, Mathf.Infinity, mouseLayerMask);
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.tag == "Meteor") {
                //FireCannon();
                Debug.LogWarning("Hit " + hit.transform.name);
            }
        }
    }
}
