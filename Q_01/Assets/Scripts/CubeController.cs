using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Vector3 SetPoint { get; private set; }


    // 외부에서 값을 받아서 수정 할 수 있게 변경
    public void SetPosition(Vector3 setpoint)
    {
        SetPoint = setpoint;
        transform.position = SetPoint;
    }
}
