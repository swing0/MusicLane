
using UnityEngine;

public class TypeChange
{
    public static Vector3 StringToVector3(string str)
    {
        str = str.Replace("(", " ").Replace(")", " "); //���ַ�����"("��")"�滻Ϊ" "
        string[] s = str.Split(',');
        return new Vector3(float.Parse(s[0]), float.Parse(s[1]), float.Parse(s[2]));
    }

}
