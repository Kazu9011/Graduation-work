using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateCatch : IPlayerState
{
    Player _player;


    public EPlayerState State => EPlayerState.Catch;
    public PlayerStateCatch(Player plaeyr) => _player = plaeyr;

    public void Entry()
    {
        _player.CurretCatchInterval = _player.CatchIntervalTime;
        Debug.Log("ƒ{[ƒ‹‚ğ‚Â‚©‚ñ‚¾");
        _player.CatchFlag = true;
        _player.SetState(EPlayerState.Idle);
    }
    void IPlayerState.Update()
    {
        
    }

    public void Exit()
    {
        
    }

   


}
