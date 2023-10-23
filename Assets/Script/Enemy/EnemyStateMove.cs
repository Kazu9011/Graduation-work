using UnityEngine;
using UnityEngine.AI;


public class EnemyStateMove : IEnemyState
{
    Enemy _enemy;
    GameObject ballobj;
    GameObject enemyobj;
    
    public EEnemyState State => EEnemyState.Move;
    public EnemyStateMove( Enemy plaeyr) => _enemy = plaeyr;
    public void Entry()
    {
        //_enemy.SetAnimation("Move", true);
        Debug.Log("“GˆÚ“®");
    }
    public void Update()
    {
        Debug.Log("“GˆÚ“®");

        // _enemy.AddVelocity(_enemy.Dir * _enemy.EnemySpeed);
        //_enemy.SetDirection(_enemy.Dir);
        //
        enemyobj = GameObject.Find("Enemy");
        NavMeshAgent agent = enemyobj.GetComponent<NavMeshAgent>();
        if (agent.enabled)
        {
            ballobj = GameObject.Find("Ball");
            agent.SetDestination(ballobj.transform.position);
        }
        

        //Enemy ene = enemyobj.GetComponent<Enemy>();
        if (_enemy.CurretEnableTime>0)
        {
            Debug.Log("‚P‚P‚P‚P‚P");
            _enemy.CurretEnableTime -= Time.deltaTime;
        }
        if (_enemy.CurretEnableTime <= 0 && agent.enabled==false)
        {
            _enemy.ChangeNavEnable(true);
        }
        if (_enemy.CatchFlag)
        {
            //ŠÔŒ¸­
            if (_enemy.CurretCatchInterval > 0) _enemy.CurretCatchInterval -= Time.deltaTime;
            //ƒ{[ƒ‹‚ğŠó‘Ô
            
            ballobj.transform.position = _enemy.transform.position + _enemy.transform.forward * _enemy.BallDistance ;
            //if (Input.GetButtonDown("A"))
            //{
            //    _enemy.SetState(EEnemyState.Aim);
            //}
        }
        
    }
    public void Exit()
    {
        //_enemy.SetAnimation("Move", false);
    }
}
