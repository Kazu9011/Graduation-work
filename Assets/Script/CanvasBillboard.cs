using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBillboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Camera.main.transform.position - this.transform.position;
        direction.x = 0;
        // オブジェクトをベクトル方向に従って回転させる
        transform.rotation = Quaternion.LookRotation(-1.0f * direction);
    }
}
