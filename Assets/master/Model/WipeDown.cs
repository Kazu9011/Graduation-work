using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeDown : MonoBehaviour
{
    bool Is_Wipe = false;
    bool Is_Pose = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PoseAnime();
        }

        if (Is_Pose && Input.GetMouseButtonDown(0))
        {
            WipeAnime();
        }

        if (Is_Wipe && Is_Pose && Input.GetKeyDown(KeyCode.Return))
        {
            WipeAnimefalse();
            PoseAnimefalse();
        }
    }

    public void WipeAnime()
    {
        Animator animator;
        Is_Wipe = true;
        animator = GetComponent<Animator>();
        animator.SetBool("Is_Wipe", Is_Wipe);
    }
    public void WipeAnimefalse()
    {
        Animator animator;
        Is_Wipe = false;
        animator = GetComponent<Animator>();
        animator.SetBool("Is_Wipe", Is_Wipe);
    }

    public void PoseAnime()
    {
        Animator animator;
        Is_Pose = true;
        animator = GetComponent<Animator>();
        animator.SetBool("Is_Pose", Is_Pose);
    }

    public void PoseAnimefalse()
    {
        Animator animator;
        Is_Pose = false;
        animator = GetComponent<Animator>();
        animator.SetBool("Is_Pose", Is_Pose);
    }
}
