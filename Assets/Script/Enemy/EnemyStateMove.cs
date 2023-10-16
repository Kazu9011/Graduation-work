using UnityEngine;



public class EnemyStateMove : IEnemyState
{
    Enemy _enemy;
    GameObject ballobj;
    public EEnemyState State => EEnemyState.Move;
    public EnemyStateMove( Enemy plaeyr) => _enemy = plaeyr;
    public void Entry()
    {
        _enemy.SetAnimation("Move", true);
    }
    public void Update()
    {
        if (_enemy.Dir.x == 0 && _enemy.Dir.z == 0)
        {
            _enemy.SetState(EEnemyState.Idle);
            
            return;
        }


        _enemy.AddVelocity(_enemy.Dir * _enemy.EnemySpeed);
        _enemy.SetDirection(_enemy.Dir);
        //
        if (_enemy.CatchFlag)
        {
            //ŠÔŒ¸­
            if (_enemy.CurretCatchInterval > 0) _enemy.CurretCatchInterval -= Time.deltaTime;
            //ƒ{[ƒ‹‚ğŠó‘Ô
            ballobj = GameObject.Find("Ball");
            ballobj.transform.position = _enemy.transform.position + _enemy.transform.forward * _enemy.BallDistance ;
            if (Input.GetButtonDown("A"))
            {
                _enemy.SetState(EEnemyState.Aim);
            }
        }
        
    }
    public void Exit()
    {
        _enemy.SetAnimation("Move", false);
    }
}
