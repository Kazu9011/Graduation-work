using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyanime : MonoBehaviour
{
    bool is_EnemyDes = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnemyAnime()
    {
        Animator animator;
        is_EnemyDes = true;
        animator = GetComponent<Animator>();
        animator.SetBool("is_EnemyDes", is_EnemyDes);
    }
}
