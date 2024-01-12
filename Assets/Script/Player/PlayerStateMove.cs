using UnityEngine;



public class PlayerStateMove : IPlayerState
{
    Player _player;
    GameObject ballobj;
    CapsuleCollider capsule;
    Rigidbody rb;
    float curretstaytime;
    public EPlayerState State => EPlayerState.Move;
    public PlayerStateMove( Player plaeyr) => _player = plaeyr;
    public void Entry()
    {
        //_player.SetAnimation("Move", true);
        capsule = _player.GetComponent<CapsuleCollider>();
        rb = _player.GetComponent<Rigidbody>();
    }
    public void Update()
    {
        
        if (_player.ChangeStay)
        {
            capsule.enabled = false;
            rb.useGravity = false;
            curretstaytime -= Time.deltaTime;
            if (curretstaytime < 0)
            {
                _player.ChangeStay = false;
                curretstaytime = _player.StayTime;
                capsule.enabled = true;
                rb.useGravity = true;
            }
            return;
        }
        else if (_player.ChangeStay == false)
        {
            _player.AddVelocity(_player.Dir * _player.PlayerSpeed);
            _player.SetDirection(_player.Dir);
            //ƒ{[ƒ‹‚ðŠŽó‘Ô
            if (_player.CatchFlag)
            {
                //ŽžŠÔŒ¸­
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
                //“ã‚¬•¥‚¢‰Â”\
                if (Input.GetButtonDown("A"))
                {
                    _player.SetState(EPlayerState.Cleave);
                }
            }
        }
        if (_player.Dir.x == 0 && _player.Dir.z == 0)
        {
            _player.SetState(EPlayerState.Idle);

            return;
        }
    }
    public void Exit()
    {
        //_player.SetAnimation("Move", false);
    }
}
