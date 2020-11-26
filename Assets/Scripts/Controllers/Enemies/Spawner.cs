using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] meteors;
    [SerializeField] Transform[] locations;
    [Range(1, 100)]
    [SerializeField] float minFrequency = 1f;
    [Range (1, 100)]
    [SerializeField] float maxFrequency = 10f;
    [Range (1, 50)]
    [SerializeField] int maxNumber = 5;

    GameObject[] targets;
    IEnumerator coroutine;
    float nextSpawnDelay = 0f;
    ArrayList spawned = null;

    void Start()
    {
        spawned = new ArrayList();
        if (meteors == null || meteors.Length == 0) {
            Destroy(this);
        }
        if (locations == null || locations.Length == 0)
        {
            Destroy(this);
        }
        targets = GameObject.FindGameObjectsWithTag("Target");
        if (maxFrequency <= minFrequency) {
            maxFrequency = minFrequency + 1;
        }
        GetSpawnDelay();
        coroutine = Spawn();
        StartCoroutine(coroutine);
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
            Vector3 target = GetTargetPosition();
            if (spawned.Count < maxNumber) {
                int randomMeteor = Random.Range(0, meteors.Length - 1);
                int randomLocation = Random.Range(0, locations.Length - 1);
                if (meteors == null || locations == null ||
                    meteors.Length == 0 || locations.Length == 0 ||
                    meteors[randomMeteor] == null || locations[randomLocation] == null) {
                    yield return null;
                }
                GameObject newSpawned = Instantiate(meteors[randomMeteor],
                            locations[randomLocation].position,
                            Quaternion.identity, null);
                Meteor meteor = newSpawned.GetComponent<Meteor>();
                meteor.SetTarget(target, this);
                spawned.Add(meteor);
            }
        }
    }

    private Vector3 GetTargetPosition()
    {
        GameObject plane = targets[Random.Range(0,targets.Length - 1)];
        Vector3 min = plane.GetComponent<MeshFilter>().mesh.bounds.min;
        Vector3 max = plane.GetComponent<MeshFilter>().mesh.bounds.max;

        Vector3 target = plane.transform.position - 
                            new Vector3 ((Random.Range(min.x*5, max.x*5)),
                                            plane.transform.position.y,
                                            (Random.Range(min.z*5, max.z*5)));
        return target;
    }

    public void ClearSpawned(Meteor meteor)
    {
        spawned.Remove(meteor);
    }
}
