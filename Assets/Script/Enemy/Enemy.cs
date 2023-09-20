using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamageEvent
{
    [SerializeField]
    EnemyData enemyData;

    int _currentHp;
    // Start is called before the first frame update
    void Start()
    {
        _currentHp = enemyData.Hp;
    }

    // Update is called once per frame
    void Update()
    {
        



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageEvent attackEvent))
        {
            attackEvent.AttackEvent(this.gameObject);
        }  
    }

    public void Damage(int val)
    {
        _currentHp -= val;

        if (_currentHp <= 0)
        {
            _currentHp = 0;
            Debug.Log("Ž€–S");
        }
        Debug.Log(_currentHp);
    }

    public void AttackEvent(GameObject obj)
    {
        var player = obj.GetComponent<Player>();
        player.Damage(50);
    }
}
