using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

public class UnityJson
{
    public static void Saves(List<EnemyFire> fire, string fileName)

    {
        string json = ObjectToJson(fire);

        File.WriteAllText(fileName, json, Encoding.UTF8);    //utf8 �����������룻 

    }

    public static List<EnemyFire> Read(string fileName)

    {

        string json = File.ReadAllText(fileName, Encoding.UTF8);

        List<EnemyFire> fire = JsonToObject(json);

        fire.ForEach(delegate (EnemyFire fires)
        {
            Debug.Log(fires);
        });

        return fire;

    }

    // JsonConvert ����֧��Vector3��json��...
    public static string ObjectToJson(List<EnemyFire> fire)
    {
        List<EnemyFireForJson> enemyFireForJsons = new List<EnemyFireForJson>();
        fire.ForEach(delegate (EnemyFire enemyFire)
        {
            enemyFireForJsons.Add(new EnemyFireForJson(enemyFire));
        }
        );
        string json = JsonConvert.SerializeObject(enemyFireForJsons);
        return json;
    }

    public static List<EnemyFire> JsonToObject(string json)
    {
        List<EnemyFire> enemyFires = new List<EnemyFire>();
        List<EnemyFireForJson> enemyFireForJsons = JsonConvert.DeserializeObject<List<EnemyFireForJson>>(json);
        enemyFireForJsons.ForEach(delegate (EnemyFireForJson enemyFireForJson)
        {
            enemyFires.Add(new EnemyFire(enemyFireForJson));
        }
        );
        return enemyFires;
    }

}
