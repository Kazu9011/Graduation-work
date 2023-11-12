using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using KanKikuchi.AudioManager;
public class Ball : MonoBehaviour
{
    GameObject explosioneffectobj;
    ParticleSystem explosion;
    //Resources.UnloadAsset(explosioneffectobj);
    GameObject Player;
    GameObject Enemy;
    FieldSetting setting;
    public float BombPower = 10.0f;
    public GameObject BallTargetObject;
    Vector3 BallRestartPos;
    public float RestartPositionOffset=10.0f;
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
        BallRestartPos = BallTargetObject.transform.position;
        BallRestartPos = BallTargetObject.transform.position;
        explosioneffectobj = (GameObject)Resources.Load("EnergyExplosion");
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
           
            Instantiate(explosioneffectobj, transform.position, Quaternion.identity);
            //爆発の力を加える
            rb.AddExplosionForce(BombPower, transform.position, 0);
            //ボールのリスポーン
            transform.position = BallRestartPos + new Vector3(Random.Range(-RestartPositionOffset, RestartPositionOffset), 0.0f, Random.Range(-5, 5));
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            SEManager.Instance.Play(SEPath.EXPLOSION);
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
            //enemy.ChangeNavEnable(false);
            //enemy.CurretEnableTime = enemy.NavEnabledTime;
            Rigidbody rb = GetComponent<Rigidbody>();
           
            Instantiate(explosioneffectobj, transform.position, Quaternion.identity);
            //爆発の力を加える
            rb.AddExplosionForce(BombPower, transform.position, 0);
            //ボールのリスポーン
            transform.position = BallRestartPos + new Vector3(Random.Range(-RestartPositionOffset, RestartPositionOffset), 0.0f, Random.Range(-5, 5));
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            SEManager.Instance.Play(SEPath.EXPLOSION);
        }

    }
}
