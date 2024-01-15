using System.Collections;
using System.Collections.Generic;



public class EnemyStateContext
{
    IEnemyState _currentState;    // ���݂̏��
    IEnemyState _previousState;   // ���O�̏��



    // ��Ԃ̃e�[�u��
    Dictionary<EEnemyState, IEnemyState> _stateTable;


    public EEnemyState State => _currentState.State;
    public void Init(Enemy enemy, EEnemyState initState)
    {
        if (_stateTable != null) return; // ���x�����������Ȃ�

        // �e��ԑI�N���X�̏�����
        var table = new Dictionary<EEnemyState, IEnemyState>
        {
            { EEnemyState.Idle, new EnemyStateIdel(enemy)},
            { EEnemyState.Move, new EnemyStateMove(enemy)},
            { EEnemyState.Dead, new EnemyStateDead(enemy)},
            { EEnemyState.Hitting, new EnemyStateHitting(enemy)},
            { EEnemyState.Catch, new EnemyStateCatch(enemy)},
            { EEnemyState.Aim, new EnemyStateAim(enemy)},
            { EEnemyState.Sparring, new EnemyStateSparring(enemy)},
            { EEnemyState.Cleave, new EnemyStateCleave(enemy)},
        };
        _stateTable = table;
        _currentState = _stateTable[initState];
        _currentState.Entry();

    }

    // �ʂ̏�ԂɕύX����
    public void ChangeState(EEnemyState next)
    {
        if (_stateTable == null) return; // ���������̎��͖���
        if (_currentState == null || _currentState.State == next)
        {
            return; // ������Ԃɂ͑J�ڂ��Ȃ�
        }
        // �ޏ� �� ���ݏ�ԕύX �� ����
        var nextState = _stateTable[next];
        _previousState = _currentState;
        _previousState?.Exit();
        _currentState = nextState;
        _currentState.Entry();
    }

    // ���݂̏�Ԃ�Update����
    public void Update() => _currentState?.Update();
}
