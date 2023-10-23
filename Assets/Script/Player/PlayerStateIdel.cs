using UnityEngine;


public class PlayerStateIdel : IPlayerState
{
    Player _player;
    GameObject ballobj;
    public EPlayerState State => EPlayerState.Idle;
    public PlayerStateIdel(Player plaeyr) => _player = plaeyr;
    public void Entry()
    {
       _player.AddVelocity(Vector3.zero);
    }
    public void Update()
    {       
        if (_player.Dir.x != 0 || _player.Dir.z != 0)
        {
            _player.SetState(EPlayerState.Move);
            return;
        }
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
        


    }
}
