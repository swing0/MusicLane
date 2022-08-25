using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EditScroller : MonoBehaviour
{
    public float beatTempo; // Ĭ��180
    public bool hasStarted;
    public AudioSource theMusic;
    public string jsonName;
    public GameObject pong, redAirPlane, airPlaneTail;
    private string filePathName;


    private string fileName;    // ����һ��string���͵ı��� ���ļ�����
    private List<EnemyFire> enemyFires = new List<EnemyFire>();

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;

        filePathName = GameObject.Find("CurrentMap").GetComponent<CurrentMap>().currentFilePathName;

        MapMessage mapMessage = FileUtil.getMapMessageByFilePathName(filePathName);
        // ��������
        getMusic music = GameObject.Find("Audio").GetComponent<getMusic>();
        music.musicPath = mapMessage.MusicPath;
        music.filePath = filePathName;
        music.removeClip();
        music.updateMusic();


        // ���ñ���ͼ
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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            getAllFires();
            FileUtil.saveFire(enemyFires, fileName);
            MapMessage mapMessage = AddMapMessage();
            FileUtil.saveFireMapMessage(mapMessage);
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
        mapMessage.FilePathName = "�����ʥ�";
        mapMessage.ImageName = "qiye.jpg";
        mapMessage.MusicName = "�����ʥ�";
        mapMessage.MusicPath = "�����ʥ�.wav";
        mapMessage.Level = "6";
        mapMessage.PongJsonName = "�����ʥ�.json";
        mapMessage.Artist = "Beverly (�ӥХ�`)";
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
                    GameObject theAirPlaneTail = Instantiate(airPlaneTail, enemyFire.Position - new Vector3(0f, 0.1f, 0f), airPlaneTail.transform.rotation);
                    theAirPlaneTail.transform.localScale = new Vector3(1f, enemyFire.AirPlaneTailTime, 1f);
                    theAirPlaneTail.GetComponentInChildren<AirPlaneTailObject>().airPlaneTailTime = enemyFire.AirPlaneTailTime;
                    break;
            }
        }
        );
    }

    private void getAllFires()
    {
        EditHitObject[] editHitObjects = GetComponentsInChildren<EditHitObject>();
        foreach(EditHitObject editHitObject in editHitObjects)
        {
            enemyFires = enemyFires.Concat(editHitObject.enemyFires).ToList<EnemyFire>();
            
        }
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
