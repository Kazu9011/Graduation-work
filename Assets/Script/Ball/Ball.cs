using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameObject Player;
    GameObject Enemy;
    FieldSetting setting;
    public float BombPower = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.name == "DogPolyart")
        {
            Debug.Log("�v���C���[�ɓ�������");
            //�t�B�[���h�ݒ�ύX
            var Walls = GameObject.FindGameObjectsWithTag("PlayerLimit");
            foreach (var wall in Walls)
            {
                setting = wall.GetComponent<FieldSetting>();
                setting.ChangeFieldCollision(false);
            }
            
            
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddExplosionForce(BombPower, transform.position, 1);

        }
        if (collision.gameObject.name == "Enemy")
        {
            Debug.Log("�G�ɓ�������");
            //�t�B�[���h�ݒ�ύX
            var Walls = GameObject.FindGameObjectsWithTag("PlayerLimit");
            foreach (var wall in Walls)
            {
                setting = wall.GetComponent<FieldSetting>();
                setting.ChangeFieldCollision(false);
            }

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddExplosionForce(BombPower, transform.position, 1);
        }

    }
}
