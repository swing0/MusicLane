using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class EditScroller : MonoBehaviour
{
    public float beatTempo; // Ĭ��180

    public bool hasStarted;

    private string fileName;    // ����һ��string���͵ı��� ���ļ�����
    private string path;        //�����и�string���͵ı���������·������
    private List<EnemyFire> enemyFires = new List<EnemyFire>();

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;

        getFileName();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = !hasStarted;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            getAllFires();
            UnityJson.Saves(enemyFires, fileName);
        }
    }

    private void FixedUpdate()
    {
        if (hasStarted)
        {
            transform.position += new Vector3(0f, beatTempo * Time.fixedDeltaTime, 0f);
        }
    }


    private void getFileName()
    {
        path = Application.dataPath + "/Map";      //��������ֵָ��·��

        fileName = "Map.json";                     //��ֵ��

        if (!Directory.Exists(path))               //�ж�·���Ƿ���ڲ����ھʹ���һ����     
        {
            Directory.CreateDirectory(path);
        }

        fileName = Path.Combine(path, fileName);     //���ļ�����·���ϲ�

        if (!File.Exists(fileName))     //�ж��� �Ƿ��Ѿ����ڲ����ھʹ���һ���ļ���

        {
            FileStream fs = File.Create(fileName);
            fs.Close();
        }
    }

    private void getAllFires()
    {
        EditHitObject[] editHitObjects = GetComponentsInChildren<EditHitObject>();
        foreach(EditHitObject editHitObject in editHitObjects)
        {
            enemyFires = enemyFires.Concat(editHitObject.enemyFires).ToList<EnemyFire>();
            
        }
    }
}
