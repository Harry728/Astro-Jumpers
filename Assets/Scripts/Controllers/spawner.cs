using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] GameObject[] meteors;
    [SerializeField] Transform[] locations;
    [Range(1, 100)]
    [SerializeField] float minFrequency = 1f;
    [Range (1, 100)]
    [SerializeField] float maxFrequency = 10f;
    [Range (1, 50)]
    [SerializeField] int maxNumber = 5;

    float nextSpawnDelay = 0f;
    IEnumerator coroutine;

    void Start()
    {
        if (meteors == null || meteors.Length == 0) {
            Destroy(this);
        }
        if (locations == null || locations.Length == 0)
        {
            Destroy(this);
        }
        if (maxFrequency <= minFrequency) {
            maxFrequency = minFrequency + 1;
        }
        GetSpawnDelay();
        coroutine = Spawn();
        StartCoroutine(coroutine);
    }

    void Update()
    {
        
    }

    private void GetSpawnDelay()
    {
        nextSpawnDelay = Random.Range(minFrequency, maxFrequency);
    }

    private IEnumerator Spawn()
    {
        while (true) {
            yield return new WaitForSeconds(nextSpawnDelay);
            GetSpawnDelay();
            if (GameObject.FindGameObjectsWithTag("Meteor").Length < maxNumber) {
                Instantiate(meteors[Random.Range(0, meteors.Length - 1)],
                            locations[Random.Range(0, locations.Length - 1)]);
            }
        }
    }
}
