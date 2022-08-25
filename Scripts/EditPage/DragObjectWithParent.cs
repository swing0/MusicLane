using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObjectWithParent : MonoBehaviour
{
    public GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
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
        mainCamera.GetComponent<MoveCamera>().canReSize = false;
    }

    void OnMouseExit()
    {
        gameObject.transform.GetComponent<AirPlaneTailObject>().airPlaneTailTime = gameObject.transform.parent.localScale.y;
        gameObject.transform.parent.GetComponent<ReSizeObject>().canReSize = false;
        mainCamera.GetComponent<MoveCamera>().canReSize = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "AirPlane")
        {
            other.GetComponent<AirPlaneObject>().airPlaneTailTime = gameObject.transform.GetComponent<AirPlaneTailObject>().airPlaneTailTime;
        }
    }
}
