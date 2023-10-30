using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Ball : MonoBehaviour
{
    GameObject Player;
    GameObject Enemy;
    FieldSetting setting;
    public float BombPower = 10.0f;
    bool catchflag;
    public bool CatchFlag
    {
        get
        {
            return catchflag;
        }
        set
        {
            catchflag = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CatchFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.name == "DogPolyart" && CatchFlag==false)
        {
            Debug.Log("プレイヤーに当たった");
            //フィールド設定変更
            var Walls = GameObject.FindGameObjectsWithTag("PlayerLimit");
            foreach (var wall in Walls)
            {
                setting = wall.GetComponent<FieldSetting>();
                setting.ChangeFieldCollision(false);
            }
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddExplosionForce(BombPower, transform.position, 0);

        }
        if (collision.gameObject.name == "Enemy" && CatchFlag == false)
        {
            Debug.Log("敵に当たった");
            //フィールド設定変更
            var Walls = GameObject.FindGameObjectsWithTag("PlayerLimit");
            foreach (var wall in Walls)
            {
                setting = wall.GetComponent<FieldSetting>();
                setting.ChangeFieldCollision(false);
            }
            Enemy = GameObject.Find("Enemy");
            Enemy enemy = Enemy.GetComponent<Enemy>();
            enemy.ChangeNavEnable(false);
            enemy.CurretEnableTime = enemy.NavEnabledTime;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddExplosionForce(BombPower, transform.position, 0);

            

        }

    }
}
