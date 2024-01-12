using UnityEngine;


public class PlayerStateIdel : IPlayerState
{
    Player _player;
    GameObject ballobj;
    public EPlayerState State => EPlayerState.Idle;
    public PlayerStateIdel(Player plaeyr) => _player = plaeyr;
    public void Entry()
    {
        Debug.Log("プレイヤー停止");
        _player.AddVelocity(Vector3.zero);
    }
    public void Update()
    {       
        if (_player.Dir.x != 0 || _player.Dir.z != 0)
        {
            _player.SetState(EPlayerState.Move);
            return;
        }
        //ボールを所持状態
        if (_player.CatchFlag)
        {
            //時間減少
            if (_player.CurretCatchInterval > 0) _player.CurretCatchInterval -= Time.deltaTime;
           
            ballobj = GameObject.Find("Ball");
            ballobj.transform.position = _player.transform.position + _player.transform.forward * _player.BallDistance + _player.transform.up * 0.2f;
            if (Input.GetButtonDown("A"))
            {
                _player.SetState(EPlayerState.Aim);
            }
        }
        else
        {
            //薙ぎ払い可能
            if (Input.GetButtonDown("A"))
            {
                _player.SetState(EPlayerState.Cleave);
            }
        }
    }
    public void Exit()
    {
        


    }
}
