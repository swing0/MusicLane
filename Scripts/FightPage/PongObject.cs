using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongObject : MonoBehaviour
{

    public bool canBePressed;
    public GameObject goodEffect, greatEffect, perfectEffect, missEffect;

    private KeyCode keyToPress; // 接收hitController中的值
    private HitController hitController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
                if (Mathf.Abs(transform.position.y) > 0.5)
                {
                    //GameManager.instance.NormalHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y) > 0.25)
                {
                    //GameManager.instance.GoodHit();
                    Instantiate(greatEffect, transform.position, greatEffect.transform.rotation);
                }
                else
                {
                    //GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            hitController = other.GetComponent<HitController>();
            keyToPress = hitController.keyToPress;
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            if (gameObject.activeSelf)
            {
                //GameManager.instance.NoteMissed();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            }
            gameObject.SetActive(false);
        }
    }
}
