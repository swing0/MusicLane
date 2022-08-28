using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class FileUtil 
{

    static string str = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string getFileName(string fileName, string filePath)
    {
        if (fileName.Equals(""))
        {
            fileName = getRandomCode();
        }

        string path = Application.streamingAssetsPath + "/map/" + filePath;      //给变量赋值指定路径

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
        return fileName;
    }




    public static void saveFire(List<EnemyFire> fire, string fileName)
    {
        UnityJson.Saves(fire, fileName);
    }

    public static List<EnemyFire> getFire(string fileName)
    {
        return UnityJson.Read(fileName);
    }


    public static void saveFireMapMessage(MapMessage mapMessage)
    {
        UnityJson.SaveMessage(mapMessage);
    }


    public static List<MapMessage> getAllCell()
    {
        string path = Application.streamingAssetsPath + "/map/";
        string jsonName = "/mapMessage.json";
        List<MapMessage> mapMessages = new List<MapMessage>();
        if (Directory.Exists(path))
        {
            DirectoryInfo direction = new DirectoryInfo(path);
            DirectoryInfo[] folders = direction.GetDirectories("*", SearchOption.TopDirectoryOnly);
            for(int i = 0; i < folders.Length; i++)
            {
                string fileName = path + folders[i].Name + jsonName;
                MapMessage mapMessage = UnityJson.ReadMessage(fileName);
                mapMessages.Add(mapMessage);
            }

        }
        return mapMessages;
    }

    public static MapMessage getMapMessageByFilePathName(string filePathName)
    {
        string fileName = Application.streamingAssetsPath + "/map/" + filePathName + "/mapMessage.json";
        MapMessage mapMessage = UnityJson.ReadMessage(fileName);
        return mapMessage;
    }

    public static Sprite getSprite(string imageName, string filePath)
    {
        string fileName = getFileName(imageName, filePath);
        FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        fileStream.Seek(0, SeekOrigin.Begin);
        //创建文件长度缓冲区
        byte[] bytes = new byte[fileStream.Length];
        //读取文件
        fileStream.Read(bytes, 0, (int)fileStream.Length);
        //释放文件读取流
        fileStream.Close();
        fileStream.Dispose();
        fileStream = null;

        //创建Texture
        int width = 1920;
        int height = 1080;
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(bytes);

        //创建Sprite
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        return sprite;
    }

    public static string getRandomCode()
    {
        char[] chars = str.ToCharArray();
        StringBuilder strRan = new StringBuilder();
        System.Random ran = new System.Random();
        for (int i = 0; i < 10; i++)
        {
            strRan.Append(chars[ran.Next(0, 36)]);
        }
        return strRan.ToString();
    }

    [System.Obsolete]
    public static IEnumerator IELoadExternalAudioWebRequest(string _url, AudioSource audioSource, AudioType _audioType)
    {
        UnityWebRequest _unityWebRequest = UnityWebRequestMultimedia.GetAudioClip(_url, _audioType);
        yield return _unityWebRequest.SendWebRequest();
        if (_unityWebRequest.isHttpError || _unityWebRequest.isNetworkError)
        {
            Debug.Log(_unityWebRequest.error.ToString());
        }
        else
        {
            AudioClip _audioClip = DownloadHandlerAudioClip.GetContent(_unityWebRequest);
            audioSource.clip = _audioClip;
        }
    }


    // 初始化SD小人
    public static void initSDObject(string name,GameObject SDObject)
    {
        string fileName = "SD/" + name + "/" + name + "_SkeletonData";
        var res = Resources.Load<SkeletonDataAsset>(fileName);
        SkeletonAnimation skeletonAnimation = SDObject.GetComponent<SkeletonAnimation>();
        skeletonAnimation.skeletonDataAsset = res;
        skeletonAnimation.Initialize(true);
        SDObject.GetComponent<SDController>().initSkeletion();
    }
}
