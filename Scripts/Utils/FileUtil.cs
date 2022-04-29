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

        string path = Application.streamingAssetsPath + "/" + filePath;      //给变量赋值指定路径

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

    public static void saveFire(List<EnemyFire> fire, string fileName)
    {
        UnityJson.Saves(fire, fileName);
    }

    public static List<EnemyFire> getFire(string fileName)
    {
        return UnityJson.Read(fileName);
    }

    public static Sprite getSprite(string imageName)
    {
        string fileName = getFileName(imageName, "map/悠久のカタルシス02156");
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

}
