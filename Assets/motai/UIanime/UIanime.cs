using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIanime : MonoBehaviour
{
    bool is_PlayerDes = false;
    bool is_EnemyDes = false;

    float playertime;
    float enemytime;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    is_PlayerDes = true;
        //    animator = GetComponent<Animator>();
        //    animator.SetBool("isBattle", is_PlayerDes);
        //    playertime += Time.deltaTime;
        //}

        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    is_EnemyDes = true;
        //    animator = GetComponent<Animator>();
        //    animator.SetBool("isBattle", is_EnemyDes);
        //    enemytime += Time.deltaTime;
        //}

        //if(is_PlayerDes)
        //{
        //    if(playertime >= 1.0f)
        //    {
        //        is_PlayerDes = false;
        //        animator = GetComponent<Animator>();
        //        animator.SetBool("isBattle", is_PlayerDes);
        //        playertime = 0.0f;
        //    }
        //}

        //if(is_EnemyDes)
        //{
        //    if(enemytime >= 1.0f)
        //    {
        //        is_EnemyDes = false;
        //        animator = GetComponent<Animator>();
        //        animator.SetBool("isBattle", is_EnemyDes);
        //        enemytime = 0.0f;
        //    }
        //}
    }
    
    public void PlayerAnime()
    {
        Debug.Log("�G���_�A�j��");
        Animator animator;
        is_PlayerDes = true;
        animator = GetComponent<Animator>();
        animator.SetBool("isBattle", is_PlayerDes);
    }

    public void EnnmyAnime()
    {
        Debug.Log("�v���C���[���_�A�j��");
        Animator animator;
        is_EnemyDes = true;
        animator = GetComponent<Animator>();
        animator.SetBool("isBattle", is_EnemyDes);
    }
}
