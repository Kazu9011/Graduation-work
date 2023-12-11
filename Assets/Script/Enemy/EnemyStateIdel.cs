using UnityEngine;


public class EnemyStateIdel : IEnemyState
{
    Enemy _enemy;
    GameObject ballobj;
    public EEnemyState State => EEnemyState.Idle;
    public EnemyStateIdel(Enemy plaeyr) => _enemy = plaeyr;
    public void Entry()
    {
       _enemy.AddVelocity(Vector3.zero);
    }
    public void Update()
    {       
        //if (_enemy.Dir.x != 0 || _enemy.Dir.z != 0)
        //{
        //    _enemy.SetState(EEnemyState.Move);
        //    return;
        //}
        if (_enemy.CatchFlag)
        {
            //ŠÔŒ¸­
            if (_enemy.CurretCatchInterval > 0) _enemy.CurretCatchInterval -= Time.deltaTime;
            //ƒ{[ƒ‹‚ğŠó‘Ô
            ballobj = GameObject.Find("Ball");
            ballobj.transform.position = _enemy.transform.position + _enemy.transform.forward * _enemy.BallDistance + _enemy.transform.up * 0.2f;
            //if (Input.GetButtonDown("A"))
            //{
            //    _enemy.SetState(EEnemyState.Aim);
            //}
        }
    }
    public void Exit()
    {
        


    }
}
