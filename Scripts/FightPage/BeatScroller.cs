using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float beatTempo; // Ĭ��180
    public bool hasStarted;
    public GameObject pong, redAirPlane, airPlaneTail;


    private string filePathName;
    private List<EnemyFire> enemyFires = new List<EnemyFire>();

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
        filePathName = GameObject.Find("CurrentMap").GetComponent<CurrentMap>().currentFilePathName;
        CreateEnemyByFile();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {

        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.fixedDeltaTime, 0f);
        }
    }

    private void CreateEnemyByFile()
    {
        string jsonName = FileUtil.getMapMessageByFilePathName(filePathName).PongJsonName;
        string fileName = FileUtil.getFileName(jsonName, filePathName);
        enemyFires = FileUtil.getFire(fileName);
        enemyFires.ForEach(delegate (EnemyFire enemyFire)
        {
            switch (enemyFire.Type)
            {
                case "Pong":
                    GameObject thePong = Instantiate(pong, enemyFire.Position, pong.transform.rotation);
                    thePong.transform.parent = this.transform;
                    break;
                case "AirPlane":
                    GameObject theAirPlane = Instantiate(redAirPlane, enemyFire.Position, redAirPlane.transform.rotation);
                    theAirPlane.transform.parent = this.transform;
                    theAirPlane.GetComponent<AirPlaneObject>().airPlaneTailTime = enemyFire.AirPlaneTailTime;
                    break;
                case "AirPlaneTail":
                    GameObject theAirPlaneTail = Instantiate(airPlaneTail, enemyFire.Position, airPlaneTail.transform.rotation);
                    theAirPlaneTail.transform.localScale = new Vector3(1f, enemyFire.AirPlaneTailTime, 1f);
                    theAirPlaneTail.GetComponentInChildren<AirPlaneTailObject>().airPlaneTailTime = enemyFire.AirPlaneTailTime;
                    theAirPlaneTail.transform.parent = this.transform;
                    break;
            }
        }
        );
    }
}
