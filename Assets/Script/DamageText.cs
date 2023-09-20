using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DamageText : MonoBehaviour
{
    //List<GameObject> gameObjects;
    TextMeshProUGUI text;
    static Vector3 pos;
    static int _val;

    static bool update;
    // Start is called before the first frame update
    void Start()
    {       
        text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            transform.position = pos;
            text.text = _val.ToString();
            update = false;
        }

        Vector3 addPos = new Vector3(0, 0.02f, 0);
        transform.position += addPos;
        Vector3 direction = Camera.main.transform.position - this.transform.position;
        direction.x = 0;
        transform.rotation = Quaternion.LookRotation(-1.0f * direction);
    }

  
    static public void SetText(GameObject target, int val)
    {
        update = true;
        pos = target.transform.position;
        _val = val;
    }
}
