using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float moveSpeed;
    public float MoveSpeed
    {
        // �ڱ� �ڽ��� ��ȯ�ϱ� ������ �������� �ݺ��ȴ�.
        // get => MoveSpeed;
        // private set => MoveSpeed = value;
        get => moveSpeed;
        private set => moveSpeed = value;
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        moveSpeed = 5f;
    }
}
