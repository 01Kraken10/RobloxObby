using UnityEngine;

public class MoveByDirection : MonoBehaviour // ���� ������ ����� �� �������-�����������, �� �������� ���������� ��� ������� ������� ������ ��������
{
    public Vector3 MoveDirection;
    public float MoveSpeed;
    float TrueSpeed;
    public float SpeedChange;
    void Update()
    {
        if(TrueSpeed != MoveSpeed)
        {
            TrueSpeed = Mathf.Lerp(TrueSpeed, MoveSpeed, SpeedChange); // ��� �������� ������ ��������
        }
        transform.Translate(MoveDirection * TrueSpeed * Time.deltaTime);
    }
}
