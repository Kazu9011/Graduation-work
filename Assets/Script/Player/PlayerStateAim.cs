using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateAim : IPlayerState
{
    Player _player;
    GameObject ballobj;
    public EPlayerState State => EPlayerState.Aim;
    public PlayerStateAim(Player plaeyr) => _player = plaeyr;
    public void Entry()
    {
        Debug.Log("狙い開始");
        //_player.CatchFlag = false;
    }


    public void Update()
    {
        if (Input.GetButton("A"))
        {
            //ボールを所持状態
            ballobj = GameObject.Find("Ball");
            ballobj.transform.position = _player.transform.position + _player.transform.forward * _player.BallDistance;
            if (_player.Dir==new Vector3(0.0f,0.0f,0.0f))
            {

            }
            else
            {
                _player.SetDirection(_player.Dir);
            }
            return;
        }
        if (Input.GetButtonUp("A"))
        {
            _player.SetState(EPlayerState.Hitting);
        }

    }

    public void Exit()
    {

    }
}
