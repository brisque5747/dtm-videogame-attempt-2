using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float startDelay = 1;
    private float spawnInterval = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        // this section of code is called automatically and applies to the 'Monster1' and 'Monster2' prefabs
        // this just essientally invokes the function at the bottom of the code
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], new Vector3(25, 3, 0), animalPrefabs[animalIndex].transform.rotation);
    } 
}
