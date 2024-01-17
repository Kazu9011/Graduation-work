using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateSparring : IPlayerState
{

    GameObject enemyobj;
    Enemy enemy;
    Player _player;
    float curretsparringtime;
    int sparringparameter = 50;
    int curretsparringparameter;
    float rigidity;
    private bool sparringflag;
    //スライダー
    GameObject cleavesliderobj;
    Slider cleaveslider;
    public EPlayerState State => EPlayerState.Sparring;
    public PlayerStateSparring(Player plaeyr) => _player = plaeyr;

    public void Entry()
    {
        enemyobj = GameObject.Find("Enemy");
        enemy = enemyobj.GetComponent<Enemy>();
        curretsparringtime = _player.SparringTime;
        rigidity = 4.0f;
        sparringflag = false;
        cleavesliderobj = GameObject.Find("CleaveSlider");
        cleaveslider = cleavesliderobj.GetComponent<Slider>();
        cleavesliderobj.transform.position = new Vector2(960.0f, 540.0f);
        curretsparringparameter = 0;
        cleaveslider.value = 0;
    }
    void IPlayerState.Update()
    {
        
        curretsparringtime -= Time.deltaTime;
        if (Input.GetButtonDown("A"))
        {
            Debug.Log("チャージ");
            int var;
            var = Random.Range(1, 5);
            curretsparringparameter += var;
            cleaveslider.value += var;
        }
        if (curretsparringtime < 0.0f)
        {
            
            rigidity -= Time.deltaTime;
            if (sparringflag == false)
            {
                Debug.Log("チャージ失敗");
                enemy.SetState(EEnemyState.Move);
                enemy.CatchFlag = true;
                _player.CatchFlag = false;
                sparringflag = true;
                cleavesliderobj.transform.position = new Vector2(960.0f, -540.0f);
            }
            if (rigidity<0.0f)
            {
                _player.SetState(EPlayerState.Move);
                sparringflag = false;
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
            cleavesliderobj.transform.position = new Vector2(960.0f, -540.0f);
        }
    }
    public void Exit()
    {
        
    }


    
}
