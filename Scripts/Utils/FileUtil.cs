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

        string path = Application.dataPath + "/Map";      //��������ֵָ��·��

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
