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
            isBattle = true;
            animator = GetComponent<Animator>();
            animator.SetBool("isBattle", isBattle);
        }
        else if(Input.GetKeyDown(KeyCode.Tab))
        {
            isBattle = false;
            animator = GetComponent<Animator>();
            animator.SetBool("isBattle", isBattle);
        }


        if (isBattle)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ishit = true;
               
                animator = GetComponent<Animator>();
                animator.SetBool("Ishit", Ishit);
            }
        }
        
    }
}
