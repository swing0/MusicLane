using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSizeObject : MonoBehaviour
{
    public bool canReSize = false; 
    float scale = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canReSize)
        {
            //通过键盘滑轮控制物体的缩放
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                transform.localScale += new Vector3(0, 1 * scale, 0);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0 && transform.localScale.y > 0.25)
            {
                transform.localScale -= new Vector3(0, 1 * scale, 0);
            }
        }
    }
}
