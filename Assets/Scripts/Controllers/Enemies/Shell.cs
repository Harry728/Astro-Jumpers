using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] float delayTilDie = 1f;

    private void Start()
    {
        //The bullet will die after a brief life
        Destroy(gameObject, delayTilDie);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bumper")) {
            Destroy(gameObject);
        }
    }
}
