using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateSparring : IEnemyState
{
    Enemy _enemy;
    public bool flaga;
    public EEnemyState State => EEnemyState.Sparring;
    public EnemyStateSparring(Enemy plaeyr) => _enemy = plaeyr;

    public void Entry()
    {
        _enemy.ChangeNavEnable(false);
    }


    public void Update()
    {
        
    }

    public void Exit()
    {
        _enemy.ChangeNavEnable(true);
    }
}
