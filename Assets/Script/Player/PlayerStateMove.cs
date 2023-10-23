using UnityEngine;



public class PlayerStateMove : IPlayerState
{
    Player _player;
    GameObject ballobj;
    public EPlayerState State => EPlayerState.Move;
    public PlayerStateMove( Player plaeyr) => _player = plaeyr;
    public void Entry()
    {
        _player.SetAnimation("Move", true);
    }
    public void Update()
    {
        if (_player.Dir.x == 0 && _player.Dir.z == 0)
        {
            _player.SetState(EPlayerState.Idle);
            
            return;
        }


        _player.AddVelocity(_player.Dir * _player.PlayerSpeed);
        _player.SetDirection(_player.Dir);
        //
        if (_player.CatchFlag)
        {
            //ŠÔŒ¸­
            if (_player.CurretCatchInterval > 0) _player.CurretCatchInterval -= Time.deltaTime;
            //ƒ{[ƒ‹‚ğŠó‘Ô
            ballobj = GameObject.Find("Ball");
            ballobj.transform.position = _player.transform.position + _player.transform.forward * _player.BallDistance ;
            if (Input.GetButtonDown("A"))
            {
                _player.SetState(EPlayerState.Aim);
            }
        }
        
    }
    public void Exit()
    {
        _player.SetAnimation("Move", false);
    }
}
