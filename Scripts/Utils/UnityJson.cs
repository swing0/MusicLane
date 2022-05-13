using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

public class UnityJson
{


    // 关卡内击打点的读写
    public static void Saves(List<EnemyFire> fire, string fileName)

    {
        string json = ObjectToJson(fire);

        File.WriteAllText(fileName, json, Encoding.UTF8);    //utf8 万国码避免乱码； 

    }
    public static List<EnemyFire> Read(string fileName)

    {

        string json = File.ReadAllText(fileName, Encoding.UTF8);

        List<EnemyFire> fire = JsonToObject(json);

        return fire;

    }

    // 关卡图片、音乐等信息的读写
    public static void SaveMessage(MapMessage mapMessage)

    {
        string fileName = Application.streamingAssetsPath + "/map/" + mapMessage.FilePathName + "/mapMessage.json";
        string json = JsonConvert.SerializeObject(mapMessage);

        File.WriteAllText(fileName, json, Encoding.UTF8);    //utf8 万国码避免乱码； 

    }
    public static MapMessage ReadMessage(string fileName)

    {

        string json = File.ReadAllText(fileName, Encoding.UTF8);

        return JsonConvert.DeserializeObject<MapMessage>(json);


    }


    // JsonConvert 好像不支持Vector3的json化...
    private static string ObjectToJson(List<EnemyFire> fire)
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

    private static List<EnemyFire> JsonToObject(string json)
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
