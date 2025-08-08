using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ObstacleManager : MonoBehaviour
{
    public GameObject LeftObstacle, RightObstacle, MiddleObstacle; // префабы препятствий
    public Transform SpawnPos; // позиция спавна
    public float SpawnTime = 10f; // начальное время между спавнами
    public float SpawnTimeMultiplyer; // множитель для ускорения спавна
    public float ObstaclesSpeedMultiplyer; // множитель для ускорения движения
    public int ObstaclesCount; // сколько препятствий за волну
    public int StartDelay; // задержка перед началом

    public Transform ObstaclesParent; // родитель для препятствий

    private float timer;
    private Queue<ObstacleType> spawnQueue = new Queue<ObstacleType>(); // очередь типов препятствий

    private void Start()
    {
        StartCoroutine(StartGenerate(StartDelay)); // запускаем генерацию после задержки
    }

    IEnumerator StartGenerate(int WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        GenerateObstacleSequence(ObstaclesCount); // заполняем очередь
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // если пришло время и есть что спавнить
        if (timer >= SpawnTime && spawnQueue.Count > 0)
        {
            ObstacleType nextType = spawnQueue.Dequeue();
            SpawnObstacle(nextType);
            timer = 0f;
            SpawnTime *= SpawnTimeMultiplyer; // ускоряем спавн
        }
    }

    void GenerateObstacleSequence(int count)
    {
        for (int i = 0; i < count; i++)
        {
            ObstacleType randomType = (ObstacleType)Random.Range(0, 3); // случайный тип
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
            Transform summonedObstacle = Instantiate(prefab, SpawnPos.position, Quaternion.identity).transform;
            summonedObstacle.SetParent(ObstaclesParent);
            ObstaclesParent.GetComponent<MoveByDirection>().MoveSpeed *= ObstaclesSpeedMultiplyer; // ускоряем движение
        }
    }

    public enum ObstacleType
    {
        Left,
        Middle,
        Right
    }
}
