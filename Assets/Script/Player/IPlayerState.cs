



public interface IPlayerState
{
    EPlayerState State { get; }

    
    // ��ԊJ�n���ɍŏ��Ɏ��s�����
    void Entry();

    // �t���[�����ƂɎ��s�����
    void Update();

    // ��ԏI�����Ɏ��s�����
    void Exit();
}

