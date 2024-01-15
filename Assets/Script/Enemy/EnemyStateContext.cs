using System.Collections;
using System.Collections.Generic;



public class EnemyStateContext
{
    IEnemyState _currentState;    // 現在の状態
    IEnemyState _previousState;   // 直前の状態



    // 状態のテーブル
    Dictionary<EEnemyState, IEnemyState> _stateTable;


    public EEnemyState State => _currentState.State;
    public void Init(Enemy enemy, EEnemyState initState)
    {
        if (_stateTable != null) return; // 何度も初期化しない

        // 各状態選クラスの初期化
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

    // 別の状態に変更する
    public void ChangeState(EEnemyState next)
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
