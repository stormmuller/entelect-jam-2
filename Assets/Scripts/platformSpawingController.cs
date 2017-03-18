using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawingController : MonoBehaviour
{
    public int maxChachedSections;
    public float spaceBetweenPlatforms = 2f;
    public float spawnCheckThreshHold = 2f;
    public float yPlatfomThreshhold = 2f;
    public GameObject[] sections;
    public Transform player;
    public Transform startingSection;

    private float lastSpawnedPlatformXPosition = 0;
    private float nextSpawnXPosition;
    private Transform lastSpawedSectionTransform;
    private Queue<GameObject> cachedSections = new Queue<GameObject>();

    void Start()
    {
        CalculateNextSpawnPosition();
        lastSpawedSectionTransform = startingSection;
        cachedSections.Enqueue(startingSection.gameObject);
    }

    void Update ()
    {
        if (nextSpawnXPosition - player.position.x < spawnCheckThreshHold)
        {
            SpawnRandomPlatform();
            lastSpawnedPlatformXPosition = nextSpawnXPosition;
            CalculateNextSpawnPosition();
        }

        if (cachedSections.Count > maxChachedSections)
        {
            GameObject sectionToDestroy = cachedSections.Dequeue();
            Destroy(sectionToDestroy);
        }
    }

    private void CalculateNextSpawnPosition()
    {
        nextSpawnXPosition = lastSpawnedPlatformXPosition + spaceBetweenPlatforms;
    }

    private void SpawnRandomPlatform()
    {
        GameObject sectionToSpawn = GetRandomSection();
        float randomYValue = UnityEngine.Random.Range(yPlatfomThreshhold, -yPlatfomThreshhold) + lastSpawedSectionTransform.position.y; 

        var lastSpawedSection = Instantiate(sectionToSpawn, new Vector3(nextSpawnXPosition, randomYValue, 0), Quaternion.identity);
        cachedSections.Enqueue(lastSpawedSection);

        lastSpawedSectionTransform = lastSpawedSection.transform;

        DeathController.yThreshHold = lastSpawedSectionTransform.position.y - 5;
    }

    private GameObject GetRandomSection()
    {
        int index = UnityEngine.Random.Range(0, sections.Length);
        return sections[index];
    }
}
