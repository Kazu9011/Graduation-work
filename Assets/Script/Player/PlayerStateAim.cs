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
        Debug.Log("�_���J�n");
        //_player.CatchFlag = false;
    }


    public void Update()
    {
        if (Input.GetButton("A"))
        {
            //�{�[�����������
            ballobj = GameObject.Find("Ball");
            ballobj.transform.position = _player.transform.position + _player.transform.forward * _player.BallDistance;
            _player.SetDirection(_player.Dir);
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