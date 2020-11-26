using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [SerializeField] Transform target = null;

    private void Start()
    {
        if (target == null) {
            Debug.LogError("No target for moon");
            Destroy(gameObject);
        }
        GetComponent<Mover>().SetTarget(target);
    }
}
