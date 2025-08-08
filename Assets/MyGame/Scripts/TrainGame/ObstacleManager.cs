using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ObstacleManager : MonoBehaviour
{
    public GameObject LeftObstacle, RightObstacle, MiddleObstacle;
    public Transform SpawnPos;
    public float SpawnTime = 10f;
    public float SpawnTimeMultiplyer; // для ускорения спавна со временем
    public float ObstaclesSpeedMultiplyer; // для ускорения спавна со временем
    public int ObstaclesCount;
    public int StartDelay;

    public Transform ObstaclesParent;

    private float timer;
    private Queue<ObstacleType> spawnQueue = new Queue<ObstacleType>();

    private void Start()
    {
        
        StartCoroutine(StartGenerate(StartDelay));
    }

    IEnumerator StartGenerate(int WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        GenerateObstacleSequence(ObstaclesCount);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= SpawnTime && spawnQueue.Count > 0)
        {
            ObstacleType nextType = spawnQueue.Dequeue();
            SpawnObstacle(nextType);
            timer = 0f;
            SpawnTime *= SpawnTimeMultiplyer;
        }
    }

    void GenerateObstacleSequence(int count)
    {
        for (int i = 0; i < count; i++)
        {
            ObstacleType randomType = (ObstacleType)Random.Range(0, 3);
            spawnQueue.Enqueue(randomType);
        }
    }

    void SpawnObstacle(ObstacleType type)
    {
        GameObject prefab = null;

        switch (type)
        {
            case ObstacleType.Left:
                prefab = LeftObstacle;
                break;
            case ObstacleType.Middle:
                prefab = MiddleObstacle;
                break;
            case ObstacleType.Right:
                prefab = RightObstacle;
                break;
        }

        if (prefab != null)
        {
            Transform SummonedObstacle = Instantiate(prefab, SpawnPos.position, Quaternion.identity).transform;
            SummonedObstacle.SetParent(ObstaclesParent);
            ObstaclesParent.GetComponent<MoveByDirection>().MoveSpeed *= ObstaclesSpeedMultiplyer;
        }
    }

    public enum ObstacleType
    {
        Left,
        Middle,
        Right
    }
}
