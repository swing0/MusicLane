using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneTailObject : MonoBehaviour
{
    public bool canBePressed;
    public float airPlaneTailTime = 1f;

    private bool isKeyDown = false;
    private float pressTime;
    private KeyCode keyToPress; // 接收hitController中的值
    private Vector3 airPlaneTailPosition;
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
                // 记录飞机尾位置
                isKeyDown = true;
                airPlaneTailPosition = transform.parent.position;
            }
        }
        if (Input.GetKey(keyToPress))
        {
            if (canBePressed && isKeyDown && pressTime < airPlaneTailTime)
            {
                // 暂停移动
                transform.parent.position = airPlaneTailPosition;
                // 计时
                pressTime += Time.deltaTime;

                updateAirPlaneTail(airPlaneTailTime - pressTime);

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
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    void updateAirPlaneTail(float time)
    {
        transform.parent.localScale = new Vector3(1f, time, 1f);
    }
}
