using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObjectWithParent : MonoBehaviour
{

    float scale = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 position = new Vector3(transform.position.x, pos.y, transform.position.z);
        gameObject.transform.parent.transform.position = position;
    }

    void OnMouseEnter()
    {
        gameObject.transform.parent.GetComponent<ReSizeObject>().canReSize = true;
    }

    void OnMouseExit()
    {
        gameObject.transform.parent.GetComponent<ReSizeObject>().canReSize = false;
    }
}
