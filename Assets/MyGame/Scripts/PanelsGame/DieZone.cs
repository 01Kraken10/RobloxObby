using UnityEngine;

public class DieZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                other.gameObject.GetComponent<Respawn>().DoRespawn();
        }
    }
}
