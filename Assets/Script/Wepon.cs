using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour, IDamageEvent
{
    [SerializeField]
    int _attackpower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackEvent(GameObject obj)
    {
        Debug.Log("hit");
        var enemy = obj.GetComponent<Enemy>();
        int damage = (int)(_attackpower * Random.Range(0.8f, 1.5f));
        DamageText.SetText(obj, damage);
        enemy.Damage(damage);
    }
}
