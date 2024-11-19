using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private CubeController _cubeController;
    private Vector3 _cubeSetPoint;

    // 프리팹이 생성되기 전에 스크립트 내용이 할당 되므로 위치 변경
    //private void Awake()
    //{
    //    SetCubePosition(3, 0, 3);
    //}

    private void Start()
    {
        CreateCube();
        SetCubePosition(3, 0, 3);
    }

    private void SetCubePosition(float x, float y, float z)
    {
        _cubeSetPoint.x = x;
        _cubeSetPoint.y = y;
        _cubeSetPoint.z = z;
        _cubeController.SetPosition(_cubeSetPoint);
    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(_cubePrefab);
        _cubeController = cube.GetComponent<CubeController>();
        // Start에서 cubeController.SetPosition()에 위치값을 할당하므로 주석 처리
        // _cubeSetPoint = _cubeController.SetPoint;
    }
}
