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
        
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        
    }
}
