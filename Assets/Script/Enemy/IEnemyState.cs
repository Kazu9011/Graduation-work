
public interface IEnemyState
{
    EEnemyState State { get; }


    // 状態開始時に最初に実行される
    void Entry();

    // フレームごとに実行される
    void Update();

    // 状態終了時に実行される
    void Exit();
}

