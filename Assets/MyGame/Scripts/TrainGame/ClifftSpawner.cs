using UnityEngine;

public class ClifftSpawner : MonoBehaviour
{
    public GameObject[] Cliffts; // префабы обрывов
    public Transform CliftsParent; // родитель для спавна
    public float ClifftSpawnTime; // интервал между спавнами

    float Timer;

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > ClifftSpawnTime)
        {
            SummonRandomCliff(); // спавним обрыв
            Timer = 0;
        }
    }

    public void SummonRandomCliff()
    {
        GameObject cliff = Cliffts[Random.Range(0, Cliffts.Length)]; // случайный обрыв
        Transform cliffTransform = Instantiate(cliff, transform.position, Quaternion.identity).transform;

        cliffTransform.SetParent(CliftsParent); // делаем дочерним
        cliffTransform.localRotation = Quaternion.EulerAngles(0, Random.Range(0f, 360f), 0); // случайный поворот по Y
    }
}
