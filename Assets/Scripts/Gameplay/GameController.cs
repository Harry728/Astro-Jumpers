using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Ground ground = null;

    private void Start() {
        ground = GameObject.Find("Ground").GetComponent<Ground>();
    }
}
