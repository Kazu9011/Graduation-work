using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateHitting : IEnemyState
{
    Enemy _enemy;
    GameObject ballobj;
    public EEnemyState State => EEnemyState.Hitting;

    public EnemyStateHitting(Enemy plaeyr) => _enemy = plaeyr;
    
    public void Entry()
    {
        Debug.Log("É{Å[ÉãÇë≈Ç¡ÇΩ");
        _enemy.CurretCatchInterval = 0;
        _enemy.CatchFlag = false;
        ballobj = GameObject.Find("Ball");
        Rigidbody rb = ballobj.GetComponent<Rigidbody>();
        rb.AddForce(_enemy.transform.forward* _enemy.HitPower, ForceMode.Impulse);
        _enemy.SetState(EEnemyState.Idle);
    }
    // Update is called once per frame
    public void Update()
    {
        
    }
    public void Exit()
    {



    }
}
