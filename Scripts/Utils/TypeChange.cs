
using UnityEngine;

public class TypeChange
{
    public static Vector3 StringToVector3(string str)
    {
        str = str.Replace("(", " ").Replace(")", " "); //将字符串中"("和")"替换为" "
        string[] s = str.Split(',');
        return new Vector3(float.Parse(s[0]), float.Parse(s[1]), float.Parse(s[2]));
    }

}
