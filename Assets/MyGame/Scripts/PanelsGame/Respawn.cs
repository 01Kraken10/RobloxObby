using KinematicCharacterController;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform RespawnPoint;
    public KinematicCharacterMotor controller;

    public void DoRespawn()
    {
        controller.SetPosition(RespawnPoint.position, true);
    }
}
