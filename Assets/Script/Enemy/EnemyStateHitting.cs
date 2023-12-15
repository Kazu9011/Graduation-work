using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;
using DigitalRuby.LightningBolt;
public class EnemyStateHitting : IEnemyState
{
    Enemy _enemy;
    GameObject ballobj;
    Ball _ball;
    //�T���_�[
    GameObject thunderobj;
    ThunderEffect thunder;
    LightningBoltScript thunderscript;
    public EEnemyState State => EEnemyState.Hitting;

    public EnemyStateHitting(Enemy plaeyr) => _enemy = plaeyr;
    
    public void Entry()
    {
        Debug.Log("�{�[����ł���");
        _enemy.CurretCatchInterval = 0;
        _enemy.CatchFlag = false;
        ballobj = GameObject.Find("Ball");
        Rigidbody rb = ballobj.GetComponent<Rigidbody>();
        rb.AddForce(_enemy.transform.forward* _enemy.HitPower, ForceMode.Impulse);
        _ball = ballobj.GetComponent<Ball>();
        _ball.CatchFlag = false;
        _enemy.SetState(EEnemyState.Move);
        SEManager.Instance.Play(SEPath.SWING);
        //�T���_�[�G�t�F�N�g
        thunderobj = GameObject.Find("ThunderEffect");
        thunder = thunderobj.GetComponent<ThunderEffect>();
        thunder.ChangeUse = true;
        thunder.enemy = true;
    }
    // Update is called once per frame
    public void Update()
    {
        
    }
    public void Exit()
    {



    }
}
