using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class FileUtil 
{

    static string str = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string getFileName(string fileName)
    {
        if (fileName.Equals(""))
        {
            fileName = getRandomCode();
        }
        fileName = fileName + ".json";

        string path = Application.dataPath + "/Map";      //给变量赋值指定路径

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


}
