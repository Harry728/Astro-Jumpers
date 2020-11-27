using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float delayTilDie = 2f;

    private void Start()
    {
        //The bullet will die after a brief life
        Destroy(gameObject, delayTilDie);
    }
}
