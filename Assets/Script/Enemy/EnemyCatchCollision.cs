using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCatchCollision : MonoBehaviour
{
    Enemy _enemy;
    GameObject _enemyobj;
    GameObject _ballobj;
    Ball _ball;
    // Start is called before the first frame update
    void Start()
    {
        _enemyobj= GameObject.Find("Enemy");
        _enemy = _enemyobj.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider ball)
    {
        if (_enemy.CurretCatchInterval <= 0 && _enemy.CatchFlag == false)
        {
            if (ball.gameObject.name == "Ball")
            {
                _ballobj = GameObject.Find("Ball");
                _ball = _ballobj.GetComponent<Ball>();
                if (_ball.CatchFlag == false)
                {
                    _ball.CatchFlag = true;
                    _enemy.SetState(EEnemyState.Catch);
                }
            }
        }
    }
}
