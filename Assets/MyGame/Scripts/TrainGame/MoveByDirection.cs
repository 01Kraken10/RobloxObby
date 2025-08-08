using UnityEngine;

public class MoveByDirection : MonoBehaviour // этот скрипт висит на объекте-перевозчике, на которого прицепл€ют все объекты которые должны двигатс€
{
    public Vector3 MoveDirection;
    public float MoveSpeed;
    float TrueSpeed;
    public float SpeedChange;
    void Update()
    {
        if(TrueSpeed != MoveSpeed)
        {
            TrueSpeed = Mathf.Lerp(TrueSpeed, MoveSpeed, SpeedChange); // дл€ плавного старта движени€
        }
        transform.Translate(MoveDirection * TrueSpeed * Time.deltaTime);
    }
}
