using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EditHitObject : MonoBehaviour
{
    public KeyCode keyToPress;
    public GameObject pong;
    public GameObject airPlane;
    public GameObject airPlaneTail;

    private GameObject theTail;// 当前的tail

    private static float LONGPRESS = 0.25f; //按钮超过LONGPRESS判定为长按
    private float pressTime = 0f;
    private float beatTempo = 0f;
    private Vector3 pongPosition;
    private Vector3 airPlanePosition;

    private bool isCanCreateAirPlane = true;


    // Start is called before the first frame update
    void Start()
    {
        beatTempo = GameObject.Find("EditScroller").GetComponent<EditScroller>().beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        createEnemy();
        
    }


    void createEnemy()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            
        }
        if (Input.GetKey(keyToPress))
        {
            pressTime += Time.deltaTime;
            if(pressTime > LONGPRESS)
            {
                if (isCanCreateAirPlane)
                {
                    createAirPlane();
                }
                updateAirPlaneTail(pressTime);
            }
        }
        if (Input.GetKeyUp(keyToPress))
        {
            if (pressTime > LONGPRESS)
            {
                isCanCreateAirPlane = true;
            }
            else
            {
                createPong();
            }
            pressTime = 0f;
        }
    }

    void createPong()
    {
        // 消除LONGPRESS的延迟
        pongPosition = transform.position - new Vector3(0f, beatTempo * LONGPRESS, 0f);
        Instantiate(pong, pongPosition, pong.transform.rotation);
    }

    void createAirPlane()
    {
        airPlanePosition = transform.position - new Vector3(0f, beatTempo * LONGPRESS, 0f);
        Instantiate(airPlane, airPlanePosition, airPlane.transform.rotation);
        isCanCreateAirPlane = false;
        createAirPlaneTail();
    }

    void createAirPlaneTail()
    {
        // tail与飞机对齐
        theTail = Instantiate(airPlaneTail, airPlanePosition - new Vector3(0f, 0.1f, 0f), airPlaneTail.transform.rotation);
    }

    void updateAirPlaneTail(float time)
    {
        theTail.transform.localScale = new Vector3(1f,time,1f);
    }

}
