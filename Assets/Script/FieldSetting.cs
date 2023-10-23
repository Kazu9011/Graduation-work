using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSetting : MonoBehaviour
{
    public float CollisionLostTime = 180;
    BoxCollider wall;
    private float curretcollisionlosttime = 0;
    public float CurretCollisionLostTime
    {
        get
        {
            return curretcollisionlosttime;
        }
        set
        {
            curretcollisionlosttime = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurretCollisionLostTime > 0)
        {
            CurretCollisionLostTime -= Time.deltaTime;
        }
        if (CurretCollisionLostTime<=0)
        {
            ChangeFieldCollision(true);
        }
     
    }
    public void ChangeFieldCollision(bool Is)
    {
        
        wall =GetComponent<BoxCollider>();
        if (Is)
        {
            Debug.Log("•Ç‚Ì”»’è‚ð‚Â‚¯‚½");
            wall.enabled = true;
        }
        else
        {
            CurretCollisionLostTime = CollisionLostTime;
            Debug.Log("•Ç‚Ì”»’è‚ð‚¯‚µ‚½");
            wall.enabled = false;
        }
    }
}
