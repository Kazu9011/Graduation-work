using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultAnime : MonoBehaviour
{
    bool Is_Result = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResultFALSE()
    {
        Animator animator;
        Is_Result = false;
        animator = GetComponent<Animator>();
        animator.SetBool("Is_Result", Is_Result);
    }
    public void ResultTRUE()
    {
        Animator animator;
        Is_Result = true;
        animator = GetComponent<Animator>();
        animator.SetBool("Is_Result", Is_Result);
    }
}
