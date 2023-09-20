using UnityEngine;



public class PlayerStateAttack : IPlayerState
{
    Player _player;
    public EPlayerState State => EPlayerState.Attack;


    bool scondAttack;
    public PlayerStateAttack(Player plaeyr) => _player = plaeyr;
    public void Entry()
    {
        _player.SetAnimation("Attack01", true); 
    }
    public void Update()
    {
        //if(Input.GetButtonDown("A"))
        //{
        //    scondAttack = true;
        //    _player.SetAnimation("Attack02", true);
        //}
        //if (_player.CheckAnimationTime(0.2f) && scondAttack)
        //{
            
        //    //_player.SetAnimation("Attack01", false);
        //}

        if(_player.CheckAnimationTime(1.0f))
        {
            if (_player.Dir.x != 0 || _player.Dir.z != 0)
            {
                _player.SetState(EPlayerState.Move);
                return;
            }
            else
            {
                _player.SetState(EPlayerState.Idle);
                return;
            }
        }


    }
    public void Exit()
    {
        _player.SetAnimation("Attack01", false);
        _player.SetAnimation("Attack02", false);
        scondAttack = false;
    }
}