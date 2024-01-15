using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum EEnemyState
{
    Idle,
    Move,
    Dead,
    Hitting,
    Catch,
    Aim,
    Sparring,
    Cleave
}





public class Enemy : MonoBehaviour
{
    EnemyStateContext _context;
    int _currentHp;

    Rigidbody rb;
    Animator animator;
    AnimatorStateInfo animeStateInfo;
    Vector3 _dir;
    public Vector3 Dir => _dir;
    //プレイヤーステータス
    //プレイヤーの速度
    public float BallDistance = 2.0f;
    public float HitPower = 10.0f;
    public float rotationSpeed = 5.0f; // 回転速度を調整するための変数
    private Quaternion targetRotation;
    public float HitDistance = 1.5f;
    public float StayTime = 0.8f;
    public float RigidityTime = 2.0f;
    //つばぜり合い関係
    public float CleaveTime = 4.0f;
    public float SparringTime = 7.0f;
    private bool catchFlag;
    public bool CatchFlag
    {
        get
        {
            return catchFlag;
        }
        set
        {
            catchFlag = value;
        }
    }
    public float CatchIntervalTime = 10;
    private float curretcatchinterval;
    public float CurretCatchInterval
    {
        get
        {
            return curretcatchinterval;
        }
        set
        {
            curretcatchinterval = value;
        }
    }
    public float CurretEnableTime = 0;
    public float NavEnabledTime = 20;
    public void ChangeNavEnable(bool Is)
    {
        NavMeshAgent nav = GetComponent<NavMeshAgent>();
        if (Is)
        {
            Debug.Log("ナビをつけた");
            nav.enabled = true;
        }
        else
        {
            Debug.Log("ナビを消した");
            nav.enabled = false;
        }
    }
    private bool stay;
    public bool ChangeStay
    {
        get
        {
            return stay;
        }
        set
        {
            stay = value;
        }
    }
    private bool rigidity;
    public bool ChangeRigidity
    {
        get
        {
            return rigidity;
        }
        set
        {
            rigidity = value;
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();



        _currentHp = 100;


        //animeStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // Stateを初期化
        _context = new EnemyStateContext();
        _context.Init(this, EEnemyState.Move);



    }

    // Start is called before the first frame update
    void Start()
    {

    }


    private void Update()
    {
        //プレイヤー移動
        _dir = new Vector3(Input.GetAxis("L_Stick_H"), 0, Input.GetAxis("L_Stick_V")).normalized;
        _context.Update();

        //animator.Update(0f);
        //animeStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        //Mathf.Repeat(animeStateInfo.normalizedTime, 1.0f);
        //Debug.Log(animeStateInfo.length);
        //animeStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        //Debug.Log(Mathf.Repeat(animeStateInfo.normalizedTime, 1.0f));
        ////Debug.Log(_context.State);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageEvent attackEvent))
        {
            attackEvent.AttackEvent(this.gameObject);
        }
    }

    public void Damage(int val)
    {
        _currentHp -= val;
        if (_currentHp <= 0)
        {
            SetState(EEnemyState.Dead);
        }

    }

    public void AddVelocity(Vector3 vel) => rb.AddForce(vel, ForceMode.Force);
    public void SetDirection(Vector3 dir)
    {
        targetRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    //=> transform.rotation = Quaternion.LookRotation(dir);
    public void SetState(EEnemyState state) => _context.ChangeState(state);
    public void SetAnimation(string animName, bool flg) => animator.SetBool(animName, flg);

    public bool CheckAnimationTime(float val)
    {
        if (animeStateInfo.normalizedTime >= val) return true;

        return false;
    }
}
