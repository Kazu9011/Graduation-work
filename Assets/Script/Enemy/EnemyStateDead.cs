using UnityEngine;



public class EnemyStateDead : IEnemyState
{
    Enemy _enemy;
    public EEnemyState State => EEnemyState.Dead;
    public EnemyStateDead(Enemy plaeyr) => _enemy = plaeyr;
    public void Entry()
    {
        Debug.Log("Ž€–S");
    }
    public void Update()
    {
       



    }
    public void Exit() { /*...*/ }
}