using System.Collections;
using System.Collections.Generic;



public class PlayerStateContext
{
    IPlayerState _currentState;    // ���݂̏��
    IPlayerState _previousState;   // ���O�̏��



    // ��Ԃ̃e�[�u��
    Dictionary<EPlayerState, IPlayerState> _stateTable;


    public EPlayerState State => _currentState.State;
    public void Init(Player player, EPlayerState initState)
    {
        if (_stateTable != null) return; // ���x�����������Ȃ�

        // �e��ԑI�N���X�̏�����
        var table = new Dictionary<EPlayerState, IPlayerState>
        {
            { EPlayerState.Idle, new PlayerStateIdel(player)},
            { EPlayerState.Move, new PlayerStateMove(player)},
            { EPlayerState.Attack, new PlayerStateAttack(player)},
            { EPlayerState.Dead, new PlayerStateDead(player)},
        };
        _stateTable = table;
        _currentState = _stateTable[initState];
        _currentState.Entry();
        
    }

    // �ʂ̏�ԂɕύX����
    public void ChangeState(EPlayerState next)
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
