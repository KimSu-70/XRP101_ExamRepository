using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Vector3 SetPoint { get; private set; }


    // �ܺο��� ���� �޾Ƽ� ���� �� �� �ְ� ����
    public void SetPosition(Vector3 setpoint)
    {
        SetPoint = setpoint;
        transform.position = SetPoint;
    }
}
