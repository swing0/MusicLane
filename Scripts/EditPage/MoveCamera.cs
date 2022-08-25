using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public bool canReSize = true;
    float scale = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canReSize)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                transform.position += new Vector3(0, 1 * scale, 0);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                transform.position -= new Vector3(0, 1 * scale, 0);
            }
        }
    }
}
