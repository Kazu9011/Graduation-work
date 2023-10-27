using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    private GameObject playerpoint;
    private GameObject enemypoint;
    private PlayerPoint ppoint;
    private EnemyPoint epoint;
    public GameObject PlayerTargetObject;
    public GameObject EnemyTargetObject;
    public GameObject BallTargetObject;
    Vector3 PlayerRestartPos;
    Vector3 EnemyRestartPos;
    Vector3 BallRestartPos;
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
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "DogPolyart")
        {
            collision.gameObject.transform.position = PlayerRestartPos;
            epoint.CurrentPoint++;
        }
        if (collision.gameObject.name == "Enemy")
        {
            collision.gameObject.transform.position = EnemyRestartPos;
            ppoint.CurrentPoint++;
        }
        if (collision.gameObject.name == "Ball")
        {
            collision.gameObject.transform.position = BallRestartPos;
        }
    }
}
