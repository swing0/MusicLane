using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EditScroller : MonoBehaviour
{
    public float beatTempo; // 默认180
    public bool hasStarted;
    public AudioSource theMusic;
    public GameObject pong, redAirPlane, airPlaneTail;


    private string filePathName;
    private string jsonName;
    private Vector3 pongPosition, airPlanePosition, airPlaneTailPosition;
    private string fileName;    // 定义一个string类型的变量 （文件名）
    private List<EnemyFire> enemyFires = new List<EnemyFire>();
    private GameObject[] pongArray, airPlaneArray, airPlaneTailArray;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;

        filePathName = GameObject.Find("CurrentMap").GetComponent<CurrentMap>().currentFilePathName;

        MapMessage mapMessage = FileUtil.getMapMessageByFilePathName(filePathName);
        jsonName = mapMessage.PongJsonName;
        // 设置音乐
        getMusic music = GameObject.Find("Audio").GetComponent<getMusic>();
        music.musicPath = mapMessage.MusicPath;
        music.filePath = filePathName;
        music.removeClip();
        music.updateMusic();


        // 设置背景图
        getImage image = GameObject.Find("backImage").GetComponent<getImage>();
        image.filePathName = filePathName;
        image.imageName = mapMessage.ImageName;
        image.updateImage();

        fileName = FileUtil.getFileName(jsonName, filePathName);

        getMusic audio = GameObject.Find("Audio").GetComponent<getMusic>();
        audio.updateMusic();

        CreateEnemyByFile();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = !hasStarted;
            PlayMusic();
        }
    }

    private void FixedUpdate()
    {
        if (hasStarted)
        {
            transform.position += new Vector3(0f, beatTempo * Time.fixedDeltaTime, 0f);
        }
    }


    private MapMessage AddMapMessage()
    {

        MapMessage mapMessage = new MapMessage();
        mapMessage.FilePathName = "シグナル";
        mapMessage.ImageName = "qiye.jpg";
        mapMessage.MusicName = "シグナル";
        mapMessage.MusicPath = "シグナル.wav";
        mapMessage.Level = "6";
        mapMessage.PongJsonName = "シグナル.json";
        mapMessage.Artist = "Beverly (ビバリー)";
        mapMessage.MaxScore = "123456";
        mapMessage.MaxLevel = "S";
        Dictionary<string, string> wifes = new Dictionary<string, string>();
        wifes.Add("leftSD", "qiye");
        wifes.Add("midSD", "null");
        wifes.Add("rightSD", "chicheng");
        mapMessage.WifeNames = wifes;
        return mapMessage;
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
                    break;
                case "AirPlane":
                    GameObject theAirPlane = Instantiate(redAirPlane, enemyFire.Position, redAirPlane.transform.rotation);
                    theAirPlane.GetComponent<AirPlaneObject>().airPlaneTailTime = enemyFire.AirPlaneTailTime;
                    break;
                case "AirPlaneTail":
                    GameObject theAirPlaneTail = Instantiate(airPlaneTail, enemyFire.Position, airPlaneTail.transform.rotation);
                    theAirPlaneTail.transform.localScale = new Vector3(1f, enemyFire.AirPlaneTailTime, 1f);
                    theAirPlaneTail.GetComponentInChildren<AirPlaneTailObject>().airPlaneTailTime = enemyFire.AirPlaneTailTime;
                    break;
            }
        }
        );
    }

    public void getAllFires()
    {
        
        enemyFires.Clear();

        pongArray = GameObject.FindGameObjectsWithTag("Pong");
        foreach(GameObject pongObject in pongArray)
        {
            pongPosition = pongObject.transform.position;
            addToList("Pong", pongPosition, 0);
        }

        airPlaneArray = GameObject.FindGameObjectsWithTag("AirPlane");

        CircleCollider2D[] polygonCollider2Ds = new CircleCollider2D[1];
        var contactFilter2D = new ContactFilter2D();
        float airPlaneTailTime = 0;
        foreach (GameObject airPlaneObject in airPlaneArray)
        {
            int count = airPlaneObject.GetComponent<CircleCollider2D>().OverlapCollider(contactFilter2D, polygonCollider2Ds);
            if (count > 0)
            {
                airPlaneTailTime = polygonCollider2Ds[0].GetComponent<AirPlaneTailObject>().airPlaneTailTime;
            }
            airPlanePosition = airPlaneObject.transform.position;
            addToList("AirPlane", airPlanePosition, airPlaneTailTime);
        }

        airPlaneTailArray = GameObject.FindGameObjectsWithTag("AirPlaneTail");
        foreach (GameObject airPlaneTailObject in airPlaneTailArray)
        {
            airPlaneTailPosition = airPlaneTailObject.transform.position;
            addToList("AirPlaneTail", airPlaneTailPosition, airPlaneTailObject.GetComponentInChildren<AirPlaneTailObject>().airPlaneTailTime);
        }
        FileUtil.saveFire(enemyFires, fileName);
        //MapMessage mapMessage = AddMapMessage();
        //FileUtil.saveFireMapMessage(mapMessage);
    }

    public void removeAllFires()
    {
        pongArray = GameObject.FindGameObjectsWithTag("Pong");
        foreach (GameObject pongObject in pongArray)
        {
            Destroy(pongObject);
        }

        airPlaneArray = GameObject.FindGameObjectsWithTag("AirPlane");
        foreach (GameObject airPlaneObject in airPlaneArray)
        {
            Destroy(airPlaneObject);
        }

        airPlaneTailArray = GameObject.FindGameObjectsWithTag("AirPlaneTail");
        foreach (GameObject airPlaneTailObject in airPlaneTailArray)
        {
            Destroy(airPlaneTailObject);
        }
    }

    void addToList(string type, Vector3 position, float airPlaneTailTime)
    {
        EnemyFire fire = new EnemyFire(type, position, airPlaneTailTime);
        enemyFires.Add(fire);
    }

    private void PlayMusic()
    {
        if (theMusic.isPlaying)
        {
            theMusic.Pause();
        }
        else
        {
            theMusic.Play();
        }
    }
}
