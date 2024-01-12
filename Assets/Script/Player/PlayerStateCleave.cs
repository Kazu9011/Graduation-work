using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateCleave : IPlayerState
{
    float curretcleavetime;
    GameObject cleavecollisionobj;
    PlayerCleaveCollision cleavecollision;
    Player _player;
    public EPlayerState State => EPlayerState.Cleave;
    public PlayerStateCleave(Player plaeyr) => _player = plaeyr;

    public void Entry()
    {
        cleavecollisionobj = GameObject.Find("DogPolyart/CleaveCollision");
        cleavecollision = cleavecollisionobj.GetComponent<PlayerCleaveCollision>();
        cleavecollision.flag = true;
        Debug.Log("“ã‚¬•¥‚¢");
        curretcleavetime=_player.CleaveTime;
    }
    void IPlayerState.Update()
    {
        curretcleavetime -= Time.deltaTime;
        if (curretcleavetime<0.0f)
        {
            _player.SetState(EPlayerState.Idle);
        }
    }

    public void Exit()
    {
        cleavecollision.flag = false;
    }
}
