using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class DictionaryUtil
{
    private static readonly Dictionary<string, string> charaSD = new Dictionary<string, string>
    {
        {"��","null"},
        {"����","lafei"},
        {"����ż��","lafei_6"},
        {"��ǹ","biaoqiang"},
        {"��ǹż��","biaoqiang_6"},
        {"z23","z23"},
        {"z23ż��","z23_5"},
        {"�貨","lingbo"},
        {"�貨ż��","lingbo_7"},
        {"��ҵ","qiye" },
        {"������","dujiaoshou"},
        {"������˹��","beierfasite" },
        {"��˹��","bisimai" },
        {"��","chaijun" },
        {"�ܴ�","nengdai"},
        {"�����˹","nigulasi"},
        {"ŷ������","ougen"},
        {"����","changmen" },
        {"���","chicheng"},
        {"���ż��","chicheng_idol"},
        {"�Ӻ�","jiahe"},
        {"ʥ���Ǹ�","shengdiyage"},
        {"���","dafeng"},
        {"���ż��","dafeng_idol"},
        {"��Ʒ�","dahuangfeng"},
        {"Լ�˳�","yuekecheng"},
        {"����","daofeng"},
        {"ѩ��","xuefeng"},
        {"��","edu"},
        {"��ż��","edu_idol"},
        {"���","guanghui"},
        {"������","hailunna"},
        {"������","xinzexi" },
        {"����","haman"},
        {"����","hude"},
        {"��ս","yanzhan"},
        {"����ɯ��","yilishabai"},
        {"��Ũ","xinnong"},
        {"����","jiangfeng"},
        {"��˹����ż��","jiasikenie_idol"},
        {"��������","kelifulan"},
        {"��������ż��","kelifulan_idol"},
        {"����","lin"},
        {"�ʲ���","buli_super"},
        {"�п��Ƕ�","liekexingdun"},
        {"������","lisailiu"},
        {"�ðͶ�","rangbaer"},
        {"�޶�","luoen"},
        {"�޶�ż��","luoen_idol"},
        {"Ī��","moli"},
        {"Ϧ��","xili" },
        {"ŷ����","ouruola"},
        {"����","yixian"},
        {"��ʲ��","tashigan"},
        {"л�ƶ���ż��","xiefeierde_idol"},
        {"ϣ���ż��","xipeier_idol"},
        {"�����м�","salatuojia"},
        {"��","aijiangDD"},
        {"��������","baoduoliuhua"},
        {"������","qian"},
        {"����ѿ","mengya"},

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
