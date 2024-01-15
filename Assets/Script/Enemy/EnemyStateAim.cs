using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateAim : IEnemyState
{
    Enemy _enemy;
    GameObject ballobj;
    GameObject playerobj;
    float AimTime = 1.0f;
    float curretaimtime;
    public EEnemyState State => EEnemyState.Aim;
    public EnemyStateAim(Enemy plaeyr) => _enemy = plaeyr;
    public void Entry()
    {
        Debug.Log("�G�_���J�n");
        curretaimtime = AimTime;
    }


    public void Update()
    {
        
        //�{�[�����������
        ballobj = GameObject.Find("Ball");
        //ballobj.transform.position = _enemy.transform.position + _enemy.transform.forward * _enemy.BallDistance + _enemy.transform.up * 1.0f;
        //
        playerobj = GameObject.Find("DogPolyart");

        Vector3 aim = playerobj.transform.position - _enemy.transform.position;
        Quaternion look = Quaternion.LookRotation(aim);
        _enemy.transform.localRotation = look;
        ballobj.transform.position = _enemy.transform.position + _enemy.transform.forward * _enemy.BallDistance + _enemy.transform.up * 1.0f;
        curretaimtime -= Time.deltaTime;
        _enemy.SetState(EEnemyState.Hitting);
        //

    }

    public void Exit()
    {
       
    }
}
