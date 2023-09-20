using UnityEngine;



public class PlayerStateMove : IPlayerState
{
    Player _player;
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

        if (Input.GetButtonDown("A"))
        {
            _player.SetState(EPlayerState.Attack);
            return;
        }

        _player.SetVelocity(_player.Dir * 5);
        _player.SetDirection(_player.Dir);
    }
    public void Exit()
    {
        _player.SetAnimation("Move", false);
    }
}
