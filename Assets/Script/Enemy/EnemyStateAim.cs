using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateAim : IEnemyState
{
    Enemy _enemy;
    GameObject ballobj;
    GameObject playerobj;
    public EEnemyState State => EEnemyState.Aim;
    public EnemyStateAim(Enemy plaeyr) => _enemy = plaeyr;
    public void Entry()
    {
        Debug.Log("�_���J�n");
        //_enemy.CatchFlag = false;
    }


    public void Update()
    {
        
        //�{�[�����������
        ballobj = GameObject.Find("Ball");
        ballobj.transform.position = _enemy.transform.position + _enemy.transform.forward * _enemy.BallDistance;
        //
        playerobj = GameObject.Find("DogPolyart");

        Vector3 aim = playerobj.transform.position - _enemy.transform.position;
        Quaternion look = Quaternion.LookRotation(aim);
        _enemy.transform.localRotation = look;
        _enemy.SetState(EEnemyState.Hitting);
        //

    }

    public void Exit()
    {
       
    }
}