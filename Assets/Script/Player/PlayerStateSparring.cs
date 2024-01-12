using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateSparring : IPlayerState
{
    GameObject enemyobj;
    Enemy enemy;
    Player _player;
    float curretsparringtime;
    int sparringparameter = 50;
    int curretsparringparameter;
    float rigidity;
    public EPlayerState State => EPlayerState.Sparring;
    public PlayerStateSparring(Player plaeyr) => _player = plaeyr;

    public void Entry()
    {
        enemyobj = GameObject.Find("Enemy");
        enemy = enemyobj.GetComponent<Enemy>();
        curretsparringtime = _player.SparringTime;
        rigidity = 3.0f;
    }
    void IPlayerState.Update()
    {
        curretsparringtime -= Time.deltaTime;
        if (Input.GetButtonDown("A"))
        {
            Debug.Log("チャージ");
            curretsparringparameter += Random.Range(1, 5);
        }
        if (curretsparringtime < 0.0f)
        {
            Debug.Log("チャージ失敗");
            enemy.SetState(EEnemyState.Move);
            rigidity -= Time.deltaTime;
            if (rigidity<0.0f)
            {
                _player.SetState(EPlayerState.Move);
            }
        }
        if (curretsparringparameter> sparringparameter)
        {
            Debug.Log("チャージ完了");
            enemy.ChangeRigidity = true;
            enemy.CatchFlag = false;
            enemy.SetState(EEnemyState.Move);
            _player.CatchFlag = true;
            _player.SetState(EPlayerState.Move);
        }
    }
    public void Exit()
    {
        
    }


    
}
