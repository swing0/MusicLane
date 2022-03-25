using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class EditScroller : MonoBehaviour
{
    public float beatTempo; // 默认180

    public bool hasStarted;

    private string fileName;    // 定义一个string类型的变量 （文件名）
    private string path;        //定义有个string类型的变量（创建路径名）
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
        path = Application.dataPath + "/Map";      //给变量赋值指定路径

        fileName = "Map.json";                     //赋值名

        if (!Directory.Exists(path))               //判断路径是否存在不存在就创建一个；     
        {
            Directory.CreateDirectory(path);
        }

        fileName = Path.Combine(path, fileName);     //将文件名和路径合并

        if (!File.Exists(fileName))     //判断文 是否已经存在不存在就创建一个文件；

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
