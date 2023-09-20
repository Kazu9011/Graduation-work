using UnityEngine;


public class PlayerStateIdel : IPlayerState
{
    Player _player;
    public EPlayerState State => EPlayerState.Idle;
    public PlayerStateIdel(Player plaeyr) => _player = plaeyr;
    public void Entry()
    {
        _player.SetVelocity(Vector3.zero);
    }
    public void Update()
    {       
        if (_player.Dir.x != 0 || _player.Dir.z != 0)
        {
            _player.SetState(EPlayerState.Move);
            return;
        }

        if (Input.GetButtonDown("A"))
        {
            _player.SetState(EPlayerState.Attack);
            return;
        }
    }
    public void Exit()
    {
        


    }
}
