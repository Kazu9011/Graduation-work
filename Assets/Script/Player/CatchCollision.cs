using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchCollision : MonoBehaviour
{
    Player _player;
    GameObject _playerobj;
   
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
                _player.SetState(EPlayerState.Catch);
            }
        }
    }
}
