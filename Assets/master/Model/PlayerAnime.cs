using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnime : MonoBehaviour
{
    bool Ishit = false;
    bool isBattle = false;
    Animator animator ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayerBattleTrue();
        }
      
        if (isBattle && Input.GetMouseButtonDown(0))
        {
            PlayerHitTrue();
        }

        if (Ishit && isBattle && Input.GetKeyDown(KeyCode.Return))
        {
            PlayerBattleFalse();
            PlayerHitFalse();
        }

    }

    public void PlayerBattleTrue()
    {
        Animator animator;
        isBattle = true;
        animator = GetComponent<Animator>();
        animator.SetBool("isBattle", isBattle);
    }

    public void PlayerBattleFalse()
    {
        Animator animator;
        isBattle = false;
        animator = GetComponent<Animator>();
        animator.SetBool("isBattle", isBattle);
    }

    public void PlayerHitTrue()
    {
        Animator animator;
        Ishit = true;
        animator = GetComponent<Animator>();
        animator.SetBool("Ishit", Ishit);
    }

    public void PlayerHitFalse()
    {
        Animator animator;
        Ishit = false;
        animator = GetComponent<Animator>();
        animator.SetBool("Ishit", Ishit);
    }

}
