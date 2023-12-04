using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeranime : MonoBehaviour
{
    bool is_PlayerDes = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerAnime()
    {
        Animator animator;
        is_PlayerDes = true;
        animator = GetComponent<Animator>();
        animator.SetBool("is_PlayerDes", is_PlayerDes);
    }
}
