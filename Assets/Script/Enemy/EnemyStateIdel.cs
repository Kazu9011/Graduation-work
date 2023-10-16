using UnityEngine;


public class EnemyStateIdel : IEnemyState
{
    Enemy _player;
    GameObject ballobj;
    public EEnemyState State => EEnemyState.Idle;
    public EnemyStateIdel(Enemy plaeyr) => _player = plaeyr;
    public void Entry()
    {
       _player.AddVelocity(Vector3.zero);
    }
    public void Update()
    {       
        if (_player.Dir.x != 0 || _player.Dir.z != 0)
        {
            _player.SetState(EEnemyState.Move);
            return;
        }
        if (_player.CatchFlag)
        {
            //���Ԍ���
            if (_player.CurretCatchInterval > 0) _player.CurretCatchInterval -= Time.deltaTime;
            //�{�[�����������
            ballobj = GameObject.Find("Ball");
            ballobj.transform.position = _player.transform.position + _player.transform.forward * _player.BallDistance ;
            if (Input.GetButtonDown("A"))
            {
                _player.SetState(EEnemyState.Aim);
            }
        }
    }
    public void Exit()
    {
        


    }
}
