using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIanime : MonoBehaviour
{
    bool is_PlayerDes = false;
    bool is_EnemyDes = false;

    float playertime;
    float enemytime;

    playeranime playeranime;
    enemyanime enemyanime;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playeranime = GetComponent<playeranime>();
        enemyanime = GetComponent<enemyanime>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            playeranime.PlayerAnime();
            playertime += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            enemyanime.EnemyAnime();
            enemytime += Time.deltaTime;
        }

    }
    
}
