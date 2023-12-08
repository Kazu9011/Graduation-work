using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedBomb : MonoBehaviour
{
    GameObject explosioneffectobj;
    public float BombPower;
    // Start is called before the first frame update
    void Start()
    {
        explosioneffectobj = (GameObject)Resources.Load("EnergyExplosion");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Debug.Log("ŒÅ’è”š’e‚Ì”š”­");
            Rigidbody rb = GetComponent<Rigidbody>();
            //Instantiate(explosioneffectobj, transform.position, Quaternion.identity);
            //”š”­‚Ì—Í‚ð‰Á‚¦‚é
            // ”ÍˆÍ“à‚ÌRigidbody‚ÉAddExplosionForce
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2.0f);
            for (int i = 0; i < hitColliders.Length; i++)
            {
                var rbs = hitColliders[i].GetComponent<Rigidbody>();
                if (rbs)
                {
                    rbs.AddExplosionForce(BombPower, transform.position, 2.0f, 0, ForceMode.Impulse);
                }
            }
        }
    }
}
