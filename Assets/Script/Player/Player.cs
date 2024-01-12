using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EPlayerState
{
    Idle,
    Move,
    Dead,
    Hitting,
    Catch,
    Aim,
    Cleave,
    Sparring,
}

public class Player : MonoBehaviour
{
    //
    GameObject starttimeobj;
    StartTimer starttimer;
    
    //
    PlayerStateContext _context;
    int _currentHp;

    Rigidbody rb;
    Animator animator;
    AnimatorStateInfo animeStateInfo;
    Vector3 _dir;
    public Vector3 Dir => _dir;
    //プレイヤーステータス
    //プレイヤーの速度
    public float PlayerSpeed = 50.0f;
    public float BallDistance = 2.0f;
    public float HitPower = 10.0f;
    public float RotationSpeed = 5.0f; // 回転速度を調整するための変数
    private Quaternion targetRotation;
    public float StayTime = 0.8f;
    //つばぜり合い関係
    public float CleaveTime = 4.0f; 
    public float SparringTime=7.0f;
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
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        
   

        _currentHp = 100;

        
        //animeStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // Stateを初期化
        _context = new PlayerStateContext();
        _context.Init(this, EPlayerState.Idle);

       

    }

    // Start is called before the first frame update
    void Start()
    {
        starttimeobj = GameObject.Find("StartTime");
        starttimer = starttimeobj.GetComponent<StartTimer>();
    }


    private void Update()
    {

        //プレイヤー移動
        if (starttimer.timeflag == false)
        {
            _dir = new Vector3(Input.GetAxis("L_Stick_H"), 0, Input.GetAxis("L_Stick_V")).normalized;
            //Debug.Log(Input.GetAxis("L_Stick_H"));
            //Debug.Log(Input.GetAxis("L_Stick_V"));

        }
        

        _context.Update();

        animator.Update(0f);
        animeStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        Mathf.Repeat(animeStateInfo.normalizedTime, 1.0f);
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
            SetState(EPlayerState.Dead);
        }
      
    }

    public void AddVelocity(Vector3 vel) => rb.AddForce(vel-rb.velocity, ForceMode.Force);
    public void SetDirection(Vector3 dir)
    {
        targetRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    }
    //=> rb.rotation = Quaternion.LookRotation(dir);
    public void SetState(EPlayerState state) => _context.ChangeState(state);
    public void SetAnimation(string animName, bool flg) => animator.SetBool(animName, flg);
   
    public bool CheckAnimationTime(float val)
    {
        if (animeStateInfo.normalizedTime >= val) return true;

        return false;
    }
}
