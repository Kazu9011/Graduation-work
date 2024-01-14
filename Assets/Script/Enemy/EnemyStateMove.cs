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
    float curretrigiditytime;
    public EEnemyState State => EEnemyState.Move;
    public EnemyStateMove( Enemy plaeyr) => _enemy = plaeyr;
    public void Entry()
    {
        //_enemy.SetAnimation("Move", true);
        Debug.Log("�G�ړ�");
        playerobj = GameObject.Find("DogPolyart");
        curretstaytime = _enemy.StayTime;
        curretrigiditytime = _enemy.RigidityTime;
        capsule = _enemy.GetComponent<CapsuleCollider>();
        rb = _enemy.GetComponent<Rigidbody>();
        _enemy.CurretCatchInterval = 0.0f;
    }
    public void Update()
    {
        if (_enemy.ChangeRigidity)
        {
            curretrigiditytime -= Time.deltaTime;
            if (curretrigiditytime < 0)
            {
                _enemy.ChangeRigidity = false;
                curretrigiditytime = _enemy.RigidityTime;
                _enemy.CatchFlag = false;
            }
        }
        else if (_enemy.ChangeStay)
        {
            Debug.Log("�G��~��");
            curretstaytime -= Time.deltaTime;
            _enemy.ChangeNavEnable(false);
            //�ꎞ�G�ɖ��G
            capsule.enabled = false;
            rb.useGravity = false;
            if (curretstaytime<0)
            {
                _enemy.ChangeStay = false;
                curretstaytime = _enemy.StayTime;
                _enemy.ChangeNavEnable(true);
                //���G����
                capsule.enabled = true;
                rb.useGravity = true;
            }
        }
        else if (_enemy.ChangeStay== false)
        {
            Debug.Log("�G�ړ�");
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
                    //�v���C���[��ǂ�
                    agent.SetDestination(playerobj.transform.position);
                }
                else
                {
                    //�{�[����ǂ�
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
                //���Ԍ���
                if (_enemy.CurretCatchInterval > 0) _enemy.CurretCatchInterval -= Time.deltaTime;
                //�{�[�����������
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
