using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatchCollision : MonoBehaviour
{
    Player _player;
    GameObject _playerobj;
    GameObject _ballobj;
    Ball _ball;
    // Start is called before the first frame update
    void Start()
    {
        _playerobj= GameObject.Find("DogPolyart");
        _player = _playerobj.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider ball)
    {
        if (_player.CurretCatchInterval <= 0 && _player.CatchFlag == false)
        {
            if (ball.gameObject.name == "Ball")
            {
                _ballobj = GameObject.Find("Ball");
                _ball = _ballobj.GetComponent<Ball>();
                if (_ball.CatchFlag==false)
                {
                    _ball.CatchFlag = true;
                    _player.SetState(EPlayerState.Catch);
                }
               
            }
        }
    }
}
