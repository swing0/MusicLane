using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class DictionaryUtil
{
    private static readonly Dictionary<string, string> charaSD = new Dictionary<string, string>
    {
        {"��","null"},
        {"����","lafei" },
        {"��ǹ","biaoqiang" },
        {"z23","z23" },
        {"�貨","lingbo" },
        {"��ҵ","qiye" },
        {"���","chicheng"},
        {"�Ӻ�","jiahe"},
        {"ѩ��","xuefeng" },
        {"������","dujiaoshou" },
        {"����","daofeng" },
        {"Ϧ��","xili" },
        {"����","buli_super" },
        {"Ī��","moli" },
        {"������˹��","beierfasite" },
        {"������","xinzexi" },
        {"���","dafeng" },
        {"����","jiangfeng" },
        {"����","haman" }
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

        //Linq ���� 
        var keys = charaSD.Where(q => q.Value == value).Select(q => q.Key);  //get all keys  

        List<string> keyList = (from q in charaSD
                                where q.Value == value
                                select q.Key).ToList<string>(); //get all keys  

        var firstKey = charaSD.FirstOrDefault(q => q.Value == value).Key;  //get first key  
        return firstKey;
    }

}
