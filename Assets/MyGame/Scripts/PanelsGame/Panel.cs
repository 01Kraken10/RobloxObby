using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel : MonoBehaviour
{
    public bool IsDeadly;
    public Material DeadlyMat, SafeMat;

    MeshRenderer meshRenderer;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Setup(Material deadMat, Material safeMat, bool isDeadly)
    {
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
                meshRenderer.material = DeadlyMat;
                other.gameObject.GetComponent<Respawn>().DoRespawn();
            }
            else
            {
                meshRenderer.material = SafeMat;
            }
        }
    }
}
