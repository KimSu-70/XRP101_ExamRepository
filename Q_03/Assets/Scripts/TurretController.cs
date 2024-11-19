using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform _muzzlePoint;
    [SerializeField] private CustomObjectPool _bulletPool;
    [SerializeField] private float _fireCooltime;
    
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Fire(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 코르틴이 동작 중일때만 실행하게 변경
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private void Init()
    {
        _coroutine = null;
        _wait = new WaitForSeconds(_fireCooltime);
        _bulletPool.CreatePool();
    }

    private IEnumerator FireRoutine(Transform target)
    {
        while (true)
        {
            yield return _wait;
            
            transform.rotation = Quaternion.LookRotation(new Vector3(
                target.position.x,
                0,
                target.position.z)
            );
            
            PooledBehaviour bullet = _bulletPool.TakeFromPool();
            bullet.transform.position = _muzzlePoint.position;
            bullet.OnTaken(target);
            
        }
    }

    private void Fire(Transform target)
    {
        // 중첩되서 실행 될 수도 있으니 코르틴 실행 중일때는 멈추고 실행하게 구현
        if (_coroutine != null)
        { 
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(FireRoutine(target));
    }
}
