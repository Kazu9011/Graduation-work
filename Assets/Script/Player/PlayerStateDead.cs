using UnityEngine;



public class PlayerStateDead : IPlayerState
{
    Player _player;
    public EPlayerState State => EPlayerState.Dead;
    public PlayerStateDead(Player plaeyr) => _player = plaeyr;
    public void Entry()
    {
        Debug.Log("Ž€–S");
    }
    public void Update()
    {
       



    }
    public void Exit() { /*...*/ }
}