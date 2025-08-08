using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel : MonoBehaviour // Этот скрипт висит на каждой панели
{
    public bool IsDeadly; // опасна ли панель
    public Material DeadlyMat, SafeMat; // материалы для опасной и безопасной панелей

    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>(); // кэшируем рендерер
    }

    public void Setup(Material deadMat, Material safeMat, bool isDeadly)
    {
        // задаем материалы и тип панели
        DeadlyMat = deadMat;
        SafeMat = safeMat;
        IsDeadly = isDeadly;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (IsDeadly)
            {
                meshRenderer.material = DeadlyMat; // ставим материал и респавним
                other.gameObject.GetComponent<Respawn>().DoRespawn();
            }
            else
            {
                meshRenderer.material = SafeMat; // просто меняем материал
            }
        }
    }
}
