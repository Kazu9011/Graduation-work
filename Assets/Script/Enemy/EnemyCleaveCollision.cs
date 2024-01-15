using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCleaveCollision : MonoBehaviour
{
    GameObject playerobj;
    Player player;
    GameObject enemyobj;
    Enemy enemy;
    GameObject ballobj;
    Ball ball;
    public bool flag;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collsionobj)
    {
        if (flag)
        {
            if (collsionobj.gameObject.name == "Ball")
            {
                if (ball.CatchFlag)
                {
                    Debug.Log("Ç¬ÇŒÇ∫ÇËçáÇ¢äJén");
                    player.SetState(EPlayerState.Sparring);
                    enemy.SetState(EEnemyState.Sparring);
                    flag = false;
                }
            }
        }
    }
}
