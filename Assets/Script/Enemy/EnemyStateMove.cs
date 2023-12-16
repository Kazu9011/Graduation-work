using UnityEngine;
using UnityEngine.AI;


public class EnemyStateMove : IEnemyState
{
    Enemy _enemy;
    GameObject ballobj;
    GameObject enemyobj;
    GameObject playerobj;
    CapsuleCollider capsule;
    Rigidbody rb;
    float curretstaytime;
    public EEnemyState State => EEnemyState.Move;
    public EnemyStateMove( Enemy plaeyr) => _enemy = plaeyr;
    public void Entry()
    {
        //_enemy.SetAnimation("Move", true);
        Debug.Log("敵移動");
        playerobj = GameObject.Find("DogPolyart");
        curretstaytime = _enemy.StayTime;
        capsule = _enemy.GetComponent<CapsuleCollider>();
        rb = _enemy.GetComponent<Rigidbody>();
    }
    public void Update()
    {
        if (_enemy.ChangeStay)
        {
            Debug.Log("敵停止中");
            curretstaytime -= Time.deltaTime;
            _enemy.ChangeNavEnable(false);
            //一時敵に無敵
            capsule.enabled = false;
            rb.useGravity = false;
            if (curretstaytime<0)
            {
                _enemy.ChangeStay = false;
                curretstaytime = _enemy.StayTime;
                _enemy.ChangeNavEnable(true);
                //無敵解除
                capsule.enabled = true;
                rb.useGravity = true;
            }
        }
        else if (_enemy.ChangeStay== false)
        {
            Debug.Log("敵移動");
            // _enemy.AddVelocity(_enemy.Dir * _enemy.EnemySpeed);
            //_enemy.SetDirection(_enemy.Dir);
            //
            enemyobj = GameObject.Find("Enemy");
            NavMeshAgent agent = enemyobj.GetComponent<NavMeshAgent>();
            if (agent.enabled == true)
            {
                ballobj = GameObject.Find("Ball");
                if (_enemy.CatchFlag)
                {
                    //プレイヤーを追う
                    agent.SetDestination(playerobj.transform.position);
                }
                else
                {
                    //ボールを追う
                    agent.SetDestination(ballobj.transform.position);
                }

            }
            //Enemy ene = enemyobj.GetComponent<Enemy>();
            if (_enemy.CurretEnableTime > 0)
            {
                _enemy.CurretEnableTime -= Time.deltaTime;
            }
            if (_enemy.CurretEnableTime <= 0 && agent.enabled == false)
            {
                _enemy.ChangeNavEnable(true);
            }
            if (_enemy.CatchFlag)
            {
                //時間減少
                if (_enemy.CurretCatchInterval > 0) _enemy.CurretCatchInterval -= Time.deltaTime;
                //ボールを所持状態
                ballobj.transform.position = _enemy.transform.position + _enemy.transform.forward * _enemy.BallDistance + _enemy.transform.up * 0.2f;
                float distance = Vector3.Distance(playerobj.transform.position, _enemy.transform.position);
                //Debug.Log(distance);
                if (_enemy.HitDistance > distance)
                {
                    _enemy.SetState(EEnemyState.Aim);
                }
            }
        }
    }
    public void Exit()
    {
        //_enemy.SetAnimation("Move", false);
    }
}
