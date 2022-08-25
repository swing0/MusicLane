using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObject : MonoBehaviour
{
    public bool canRemove = false;
    public GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (canRemove)
        {
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                if (this.gameObject.transform.parent != null && this.gameObject.transform.parent.name.Contains("AirPlaneTail"))
                {
                    Object.Destroy(this.gameObject.transform.parent.gameObject);
                    mainCamera.GetComponent<MoveCamera>().canReSize = true;
                }
                else
                {
                    Object.Destroy(this.gameObject);
                }
            }
        }
    }

    void OnMouseEnter()
    {
        canRemove = true;
    }

    void OnMouseExit()
    {
        canRemove = false;
    }
}
