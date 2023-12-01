using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;
public class Restart : MonoBehaviour
{
    
    private GameObject playerpoint;
    private GameObject enemypoint;
    private PlayerPoint ppoint;
    private EnemyPoint epoint;
    //
    public GameObject PlayerTargetObject;
    public GameObject EnemyTargetObject;
    public GameObject BallTargetObject;
    Vector3 PlayerRestartPos;
    Vector3 EnemyRestartPos;
    Vector3 BallRestartPos;
    //
    private GameObject playerobj;
    private GameObject enemyobj;
    private Rigidbody playerrg;
    private Rigidbody enemyrg;
    private GameObject bursteffectobj;
    private GameObject restarteffectobj;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRestartPos = PlayerTargetObject.transform.position;
        EnemyRestartPos = EnemyTargetObject.transform.position;
        BallRestartPos = BallTargetObject.transform.position;
        MeshRenderer playerposmr = PlayerTargetObject.GetComponent<MeshRenderer>();
        MeshRenderer enemyposmr = EnemyTargetObject.GetComponent<MeshRenderer>();
        MeshRenderer ballposmr = BallTargetObject.GetComponent<MeshRenderer>();
        playerposmr.enabled = false;
        enemyposmr.enabled = false;
        ballposmr.enabled = false;
        playerpoint = GameObject.Find("PlayerPoint");
        enemypoint = GameObject.Find("EnemyPoint");
        ppoint = playerpoint.GetComponent<PlayerPoint>();
        epoint = enemypoint.GetComponent<EnemyPoint>();
        playerobj= GameObject.Find("DogPolyart");
        enemyobj = GameObject.Find("Enemy");
        playerrg = playerobj.GetComponent<Rigidbody>();
        enemyrg = enemyobj.GetComponent<Rigidbody>();
        bursteffectobj = (GameObject)Resources.Load("Burst");
        restarteffectobj = (GameObject)Resources.Load("restart");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "DogPolyart")
        {
            Instantiate(bursteffectobj, collision.transform.position, Quaternion.identity);
            collision.gameObject.transform.position = PlayerRestartPos;
            epoint.CurrentPoint++;
            playerrg.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            SEManager.Instance.Play(SEPath.BURST);
            Instantiate(restarteffectobj, collision.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.name == "Enemy")
        {
            Instantiate(bursteffectobj, collision.transform.position, Quaternion.identity);
            collision.gameObject.transform.position = EnemyRestartPos;
            ppoint.CurrentPoint++;
            enemyrg.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            SEManager.Instance.Play(SEPath.BURST);
            Instantiate(restarteffectobj, collision.transform.position, Quaternion.identity);

        }
        if (collision.gameObject.name == "Ball")
        {
            collision.gameObject.transform.position = BallRestartPos;
        }
    }
}
