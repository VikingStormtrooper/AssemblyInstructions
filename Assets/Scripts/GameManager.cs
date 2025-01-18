using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject helicopterAsset;
    float lowerRandomTime = 30.0f;
    float upperRandomTime = 60.0f;
    float lowerHelicopterAltitude = 30.0f;
    float higherHelicopterAltitude = 50.0f;
    float lowerHelicopterHorizontalDistance = -100.0f;
    float upperHelicopterHorizontalDistance = -200.0f;
    float helicopterSpawnRange = -500.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnHelicopter());
    }

    // Spawns a new helicopter after a random amount of time
    IEnumerator SpawnHelicopter()
    {
        float spawnTime = Random.Range(lowerRandomTime, upperRandomTime);
        float randomHorizontalDistance = Random.Range(lowerHelicopterHorizontalDistance, upperHelicopterHorizontalDistance);
        float randomAltitude = Random.Range(lowerHelicopterAltitude,higherHelicopterAltitude);
        float helicopterSpawnPosition = helicopterSpawnRange;
        int randomSpawnPosition;

        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            // Randomly spawns helicopter to the left or to the right
            spawnTime = Random.Range(lowerRandomTime, upperRandomTime);
            randomHorizontalDistance = Random.Range(lowerHelicopterHorizontalDistance, upperHelicopterHorizontalDistance);
            randomAltitude = Random.Range(lowerHelicopterAltitude, higherHelicopterAltitude);
            randomSpawnPosition = Random.Range(0, 2);
            if (randomSpawnPosition == 0)
            {
                helicopterSpawnPosition = helicopterSpawnRange;
            }
            else if (randomSpawnPosition == 1)
            {
                helicopterSpawnPosition = -helicopterSpawnRange;
            }

            Vector3 spawnPosition = new Vector3(randomHorizontalDistance, randomAltitude, helicopterSpawnPosition);
            Instantiate(helicopterAsset, spawnPosition, helicopterAsset.transform.rotation);
        }
    }
}