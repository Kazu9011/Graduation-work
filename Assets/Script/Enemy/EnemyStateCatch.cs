using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateCatch : IEnemyState
{
    Enemy _enemy;


    public EEnemyState State => EEnemyState.Catch;
    public EnemyStateCatch(Enemy plaeyr) => _enemy = plaeyr;

    public void Entry()
    {
        _enemy.CurretCatchInterval = _enemy.CatchIntervalTime;
        Debug.Log("�G���{�[��������");
        _enemy.CatchFlag = true;
        _enemy.SetState(EEnemyState.Aim);
        //_enemy.SetState(EEnemyState.Hitting);
    }
    void IEnemyState.Update()
    {
        
    }

    public void Exit()
    {
        
    }

   


}
