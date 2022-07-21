using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class DictionaryUtil
{
    private static readonly Dictionary<string, string> charaSD = new Dictionary<string, string>
    {
        {"无","null"},
        {"拉菲","lafei" },
        {"标枪","biaoqiang" },
        {"z23","z23" },
        {"凌波","lingbo" },
        {"企业","qiye" },
        {"赤城","chicheng"},
        {"加贺","jiahe"},
        {"雪风","xuefeng" },
        {"独角兽","dujiaoshou" },
        {"岛风","daofeng" },
        {"夕立","xili" },
        {"布里","buli_super" },
        {"莫里","moli" },
        {"贝尔法斯特","beierfasite" },
        {"新泽西","xinzexi" },
        {"大凤","dafeng" },
        {"江风","jiangfeng" },
        {"哈曼","haman" }
    };

    public static List<string> getCharaSDAllKeys()
    {
        List<string> keyList = new List<string>();
        foreach (var key in charaSD.Keys)
        {
            keyList.Add(key);
        }
        return keyList;
    }

    public static string getCharaSDValue(string key)
    {
        return charaSD[key];
    }


    public static string getKeyByValue(string value)
    {

        //Linq 方法 
        var keys = charaSD.Where(q => q.Value == value).Select(q => q.Key);  //get all keys  

        List<string> keyList = (from q in charaSD
                                where q.Value == value
                                select q.Key).ToList<string>(); //get all keys  

        var firstKey = charaSD.FirstOrDefault(q => q.Value == value).Key;  //get first key  
        return firstKey;
    }

}
