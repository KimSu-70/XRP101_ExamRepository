using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float moveSpeed;
    public float MoveSpeed
    {
        // 자기 자신을 반환하기 때문에 무한으로 반복된다.
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
