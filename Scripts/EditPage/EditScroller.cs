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


    private string fileName;    // ����һ��string���͵ı��� ���ļ�����
    private List<EnemyFire> enemyFires = new List<EnemyFire>();

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;

        fileName = FileUtil.getFileName(jsonName, "�����ʥ�");

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
        wifes.Add("middle", "qiye");
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
