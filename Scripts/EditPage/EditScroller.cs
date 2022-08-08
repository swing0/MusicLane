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
    public string jsonName;
    private string filePathName;


    private string fileName;    // 定义一个string类型的变量 （文件名）
    private List<EnemyFire> enemyFires = new List<EnemyFire>();

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;

        filePathName = GameObject.Find("CurrentMap").GetComponent<CurrentMap>().currentFilePathName;

        MapMessage mapMessage = FileUtil.getMapMessageByFilePathName(filePathName);
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
