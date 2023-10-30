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
    Aim
}

public class Player : MonoBehaviour
{
    PlayerStateContext _context;
    int _currentHp;

    Rigidbody rb;
    Animator animator;
    AnimatorStateInfo animeStateInfo;
    Vector3 _dir;
    public Vector3 Dir => _dir;
    //�v���C���[�X�e�[�^�X
    //�v���C���[�̑��x
    public float PlayerSpeed = 50.0f;
    public float BallDistance = 2.0f;
    public float HitPower = 10.0f;
    //
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
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        
   

        _currentHp = 100;

        
        //animeStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // State��������
        _context = new PlayerStateContext();
        _context.Init(this, EPlayerState.Idle);

       

    }

    // Start is called before the first frame update
    void Start()
    {

    }


    private void Update()
    {
        //�v���C���[�ړ�
        _dir = new Vector3(Input.GetAxis("L_Stick_H"), 0, Input.GetAxis("L_Stick_V")).normalized;
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
    public void SetDirection(Vector3 dir) => rb.rotation = Quaternion.LookRotation(dir);
    public void SetState(EPlayerState state) => _context.ChangeState(state);
    public void SetAnimation(string animName, bool flg) => animator.SetBool(animName, flg);
   
    public bool CheckAnimationTime(float val)
    {
        if (animeStateInfo.normalizedTime >= val) return true;

        return false;
    }
}
