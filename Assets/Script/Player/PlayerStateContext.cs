using System.Collections;
using System.Collections.Generic;



public class PlayerStateContext
{
    IPlayerState _currentState;    // 現在の状態
    IPlayerState _previousState;   // 直前の状態



    // 状態のテーブル
    Dictionary<EPlayerState, IPlayerState> _stateTable;


    public EPlayerState State => _currentState.State;
    public void Init(Player player, EPlayerState initState)
    {
        if (_stateTable != null) return; // 何度も初期化しない

        // 各状態選クラスの初期化
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

    // 別の状態に変更する
    public void ChangeState(EPlayerState next)
    {
        if (_stateTable == null) return; // 未初期化の時は無視
        if (_currentState == null || _currentState.State == next)
        {
            return; // 同じ状態には遷移しない
        }
        // 退場 → 現在状態変更 → 入場
        var nextState = _stateTable[next];
        _previousState = _currentState;
        _previousState?.Exit();
        _currentState = nextState;
        _currentState.Entry();
    }

    // 現在の状態をUpdateする
    public void Update() => _currentState?.Update();
}
