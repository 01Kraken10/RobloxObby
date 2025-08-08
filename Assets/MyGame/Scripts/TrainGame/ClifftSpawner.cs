using UnityEngine;

public class ClifftSpawner : MonoBehaviour
{
    public GameObject[] Cliffts;
    public Transform CliftsParent;
    public float ClifftSpawnTime;

    float Timer;
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > ClifftSpawnTime)
        {
            SummonRandomCliff();
            Timer = 0;
        }
    }
    public void SummonRandomCliff()
    {
        GameObject cliff = Cliffts[Random.Range(0, Cliffts.Length)];
        Transform cliffTransform = Instantiate(cliff, transform.position, Quaternion.identity).transform;
        cliffTransform.SetParent(CliftsParent);
        cliffTransform.localRotation = Quaternion.EulerAngles(0, Random.Range(0f, 360f), 0);
    }
}
