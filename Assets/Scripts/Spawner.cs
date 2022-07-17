using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


/*
 * Spawns the Mover Objects (Enemies) with an interval you determine.
 */
public class Spawner : MonoBehaviour
{
    [SerializeField] public List<GameObject> spawnableObjects;
    
    [Tooltip("The Spawner waits a random number of seconds between these two interval each time a object was spawned.")]
    [SerializeField] private float minSpawnIntervalInSeconds;
    [SerializeField] private float maxSpawnIntervalInSeconds;

    private Jumper jumper;
    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Awake()
    {
        jumper = GetComponentInChildren<Jumper>();
        //Subscribes to Reset of Player
        jumper.OnReset += DestroyAllSpawnedObjects;
        
        StartCoroutine(nameof(Spawn));
    }
    
    private IEnumerator Spawn()
    {
        GameObject randomSpwanableFromList = GetRandomSpawnableFromList();
        int randomIndex = UnityEngine.Random.Range(0, 2); 
        //var spawned;
        if(randomIndex == 1 && (randomSpwanableFromList.tag == "gold" || randomSpwanableFromList.tag == "silver" )){
            spawnedObjects.Add(Instantiate(randomSpwanableFromList, transform.position + new Vector3(0,2.4f,0), transform.rotation, transform));
            spawnedObjects.Add(Instantiate(randoSpwanable(randomSpwanableFromList.tag), transform.position, transform.rotation, transform));
        }
        else 
            spawnedObjects.Add(Instantiate(randomSpwanableFromList, transform.position, transform.rotation, transform));

        //spawnedObjects.Add(spawned);
        
        yield return new WaitForSeconds(Random.Range(minSpawnIntervalInSeconds, maxSpawnIntervalInSeconds));
        StartCoroutine(nameof(Spawn));
    }
    private void DestroyAllSpawnedObjects()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            Destroy(spawnedObjects[i]);
            spawnedObjects.RemoveAt(i);
        }
    }

    private GameObject GetRandomSpawnableFromList()
    {
        int randomIndex = UnityEngine.Random.Range(0, spawnableObjects.Count);
        return spawnableObjects[randomIndex];
    }
    private GameObject randoSpwanable(String tag)
    {
        for(int i=0;i<spawnableObjects.Count;i++){
            if(spawnableObjects[i].tag=="gold" && tag == "silver")
                return spawnableObjects[i];
            else if(spawnableObjects[i].tag=="silver" && tag == "gold")
                return spawnableObjects[i];
        }
        return spawnableObjects[0];
    }
}
