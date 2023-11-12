using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;
public class PlayerStateHitting : IPlayerState
{
    Player _player;
    GameObject ballobj;
    Ball _ball;
    public EPlayerState State => EPlayerState.Hitting;

    public PlayerStateHitting(Player plaeyr) => _player = plaeyr;
    
    public void Entry()
    {
        Debug.Log("ボールを打った");
        _player.CurretCatchInterval = 0;
        _player.CatchFlag = false;
        ballobj = GameObject.Find("Ball");
        Rigidbody rb = ballobj.GetComponent<Rigidbody>();
        rb.AddForce(_player.transform.forward* _player.HitPower, ForceMode.Impulse);
        _ball= ballobj.GetComponent<Ball>();
        _ball.CatchFlag = false;
        _player.SetState(EPlayerState.Idle);
        SEManager.Instance.Play(SEPath.SWING);
    }
    // Update is called once per frame
    public void Update()
    {
        
    }
    public void Exit()
    {



    }
}
