using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraSystem : MonoBehaviour
{
    CinemachineVirtualCamera vcamera;
    GameObject Field;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Field = GameObject.Find("Floor");
        player = GameObject.Find("DogPolyart");
        vcamera = GetComponent<CinemachineVirtualCamera>();
        vcamera.Follow = Field.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangePlayerCamera()
    {
        vcamera.Follow = player.transform;
    }
}
