using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateCleave : IEnemyState
{
    float curretcleavetime;
    GameObject cleavecollisionobj;
    EnemyCleaveCollision cleavecollision;
    Enemy _enemy;
    public EEnemyState State => EEnemyState.Cleave;
    public EnemyStateCleave(Enemy plaeyr) => _enemy = plaeyr;
    public void Entry()
    {
        cleavecollisionobj = GameObject.Find("Enemy/CleaveCollision");
        cleavecollision = cleavecollisionobj.GetComponent<EnemyCleaveCollision>();
        cleavecollision.flag = true;
        curretcleavetime = _enemy.CleaveTime;
        Debug.Log("“G“ã‚¬•¥‚¢");
    }

    void IEnemyState.Update()
    {
        curretcleavetime -= Time.deltaTime;
        if (curretcleavetime < 0.0f)
        {
            _enemy.SetState(EEnemyState.Move);
        }
    }
    public void Exit()
    {
        cleavecollision.flag = false;
    }


}
