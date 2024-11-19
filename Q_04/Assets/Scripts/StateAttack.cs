using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private WaitForSeconds _wait;
    
    public StateAttack(PlayerController controller) : base(controller)
    {
        
    }

    public override void Init()
    {
        _wait = new WaitForSeconds(_delay);
        ThisType = StateType.Attack;
    }

    public override void Enter()
    {
        // DelayRoutine Attack();을 호출하므로 내용 수정
        Controller.StartCoroutine(DelayRoutine());
    }

    public override void OnUpdate()
    {
        Debug.Log("Attack On Update");
    }

    public override void Exit()
    {
        // Exit 패턴이 종료될때 호출하면 계속해서 반복 호출하므로 주석처리
        // Machine.ChangeState(StateType.Idle);
    }

    private void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(
            Controller.transform.position,
            Controller.AttackRadius
            );

        IDamagable damagable;
        foreach (Collider col in cols)
        {
            damagable = col.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeHit(Controller.AttackValue);
            }
        }
    }

    public IEnumerator DelayRoutine()
    {
        yield return _wait;

        Attack();
        // 공격이 끝났을 때 상태 변경하도록 수정
        Machine.ChangeState(StateType.Idle);
    }

}
