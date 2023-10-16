using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateAim : IEnemyState
{
    Enemy _enemy;
    GameObject ballobj;
    public EEnemyState State => EEnemyState.Aim;
    public EnemyStateAim(Enemy plaeyr) => _enemy = plaeyr;
    public void Entry()
    {
        Debug.Log("�_���J�n");
        //_enemy.CatchFlag = false;
    }


    public void Update()
    {
        if (Input.GetButton("A"))
        {
            //�{�[�����������
            ballobj = GameObject.Find("Ball");
            ballobj.transform.position = _enemy.transform.position + _enemy.transform.forward * _enemy.BallDistance;
            _enemy.SetDirection(_enemy.Dir);
            return;
        }
        if (Input.GetButtonUp("A"))
        {
            _enemy.SetState(EEnemyState.Hitting);
        }

    }

    public void Exit()
    {

    }
}
