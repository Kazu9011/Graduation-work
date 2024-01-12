using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCleaveCollision : MonoBehaviour
{
    GameObject playerobj;
    Player player;
    GameObject enemyobj;
    Enemy enemy;
    GameObject ballobj;
    Ball ball;
    public bool flag;
    bool battleflag;
    
    // Start is called before the first frame update
    void Start()
    {
        playerobj = GameObject.Find("DogPolyart");
        player = playerobj.GetComponent<Player>();
        enemyobj = GameObject.Find("Enemy");
        enemy = enemyobj.GetComponent<Enemy>();
        ballobj = GameObject.Find("Ball");
        ball = ballobj.GetComponent<Ball>();
        flag = false;
        battleflag = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (battleflag)
        //{
        //    curretsparringTime -= Time.deltaTime;
        //    if (Input.GetButtonDown("A"))
        //    {
        //        Debug.Log("チャージ");
        //        curretsparringparameter += 5;
        //    }
        //    if (curretsparringTime<0.0f)
        //    {
        //        battleflag = false;
        //    }
        //}
    }
    private void OnTriggerEnter(Collider collsionobj)
    {
        if (flag)
        {
            if (collsionobj.gameObject.name == "Ball")
            {
                if (ball.CatchFlag)
                {
                    Debug.Log("つばぜり合い開始");
                    player.SetState(EPlayerState.Sparring);
                    enemy.SetState(EEnemyState.Sparring);
                    //battleflag = true;
                    flag = false;
                    //curretsparringTime = player.SparringTime;
                    //curretsparringparameter = 0;
                }
            }
        }  
    }
}
