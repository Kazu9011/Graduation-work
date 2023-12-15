using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;
public class ThunderEffect : MonoBehaviour
{
    LightningBoltScript thunderscript;
    private bool use;
    public bool player;
    public bool enemy;
    GameObject enemyobj;
    GameObject playerobj;
    GameObject Ball;
    public bool ChangeUse
    {
        get
        {
            return use;
        }
        set
        {
            currettime = duration;
            use = value;
        }
    }
    public float duration=100;
    private float currettime;
    // Start is called before the first frame update
    void Start()
    {
        currettime = duration;
        use = false;                                                                                                                                                                                                                                                                                                                                                                                                                                     
        thunderscript = GetComponent<LightningBoltScript>();
        player = false;
        enemy = false;
        enemyobj = GameObject.Find("Enemy");
        playerobj = GameObject.Find("DogPolyart");
        Ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (use)
        {
            Debug.Log("“dŒ‚");
            if (player)
            {
                thunderscript.StartObject.transform.position = playerobj.transform.position;
                thunderscript.EndObject.transform.position = Ball.transform.position;
                //thunderscript.EndPosition.Set(Ball.transform.position.x, Ball.transform.position.y, Ball.transform.position.z);
                //thunderscript.StartPosition.Set(playerobj.transform.position.x, playerobj.transform.position.y, playerobj.transform.position.z);
            }
            else if (enemy)
            {
                thunderscript.StartObject.transform.position = enemyobj.transform.position;
                thunderscript.EndObject.transform.position = Ball.transform.position;
                //thunderscript.EndPosition.Set(Ball.transform.position.x, Ball.transform.position.y, Ball.transform.position.z);
                //thunderscript.StartPosition.Set(enemyobj.transform.position.x, enemyobj.transform.position.y, enemyobj.transform.position.z);
            }
            thunderscript.Trigger();
            currettime -= Time.deltaTime;
            if (currettime<=0)
            {
                Debug.Log("“dŒ‚‰ðœ");
                use = false;
                player = false;
                enemy = false;
            }
        }
    }
}
