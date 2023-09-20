using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Status
{
    public int _hp;
    public int _power;
    public int _magicpower;
    public int _defense;
    public float _speed;
}


public enum SkillOrdinal
{
    First,
    Second,
    Max
}

public enum EPlayerState
{
    Idle,
    Move,
    Attack,
    Damage,
    Dead
}





public class Player : MonoBehaviour
{
    PlayerStateContext _context;
    int _currentHp;
    //Status _status;
    //int _currentExp;
    //int _nextLevelPoint;
    //int _level = 1;

    //Wepon _wepon;
    //Gear[] _gear = new Gear[(int)GearPart.Max];
    //Skill[] _skill = new Skill[2];
    //Item _item;

    Rigidbody rb;
    Animator animator;
    AnimatorStateInfo animeStateInfo;
    Vector3 _dir;
    public Vector3 Dir => _dir;

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
        _dir = new Vector3(Input.GetAxis("L_Stick_H"), 0, Input.GetAxis("L_Stick_V")).normalized;
        _context.Update();

        animator.Update(0f);
        animeStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        Mathf.Repeat(animeStateInfo.normalizedTime, 1.0f);
        Debug.Log(animeStateInfo.length);
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

    public void SetVelocity(Vector3 vel) => rb.velocity = vel;
    public void SetDirection(Vector3 dir) => rb.rotation = Quaternion.LookRotation(dir);
    public void SetState(EPlayerState state) => _context.ChangeState(state);
    public void SetAnimation(string animName, bool flg) => animator.SetBool(animName, flg);

    public bool CheckAnimationTime(float val)
    {
        if (animeStateInfo.normalizedTime >= val) return true;

        return false;
    }
}
