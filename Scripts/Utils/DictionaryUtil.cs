using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class DictionaryUtil
{
    private static readonly Dictionary<string, string> charaSD = new Dictionary<string, string>
    {
        {"无","null"},
        {"拉菲","lafei"},
        {"拉菲偶像","lafei_6"},
        {"标枪","biaoqiang"},
        {"标枪偶像","biaoqiang_6"},
        {"z23","z23"},
        {"z23偶像","z23_5"},
        {"凌波","lingbo"},
        {"凌波偶像","lingbo_7"},
        {"企业","qiye" },
        {"独角兽","dujiaoshou"},
        {"贝尔法斯特","beierfasite" },
        {"俾斯麦","bisimai" },
        {"柴郡","chaijun" },
        {"能代","nengdai"},
        {"尼古拉斯","nigulasi"},
        {"欧根亲王","ougen"},
        {"长门","changmen" },
        {"赤城","chicheng"},
        {"赤城偶像","chicheng_idol"},
        {"加贺","jiahe"},
        {"圣地亚哥","shengdiyage"},
        {"大凤","dafeng"},
        {"大凤偶像","dafeng_idol"},
        {"大黄蜂","dahuangfeng"},
        {"约克城","yuekecheng"},
        {"岛风","daofeng"},
        {"雪风","xuefeng"},
        {"恶毒","edu"},
        {"恶毒偶像","edu_idol"},
        {"光辉","guanghui"},
        {"海伦娜","hailunna"},
        {"新泽西","xinzexi" },
        {"哈曼","haman"},
        {"胡德","hude"},
        {"厌战","yanzhan"},
        {"伊丽莎白","yilishabai"},
        {"信浓","xinnong"},
        {"江风","jiangfeng"},
        {"加斯科涅偶像","jiasikenie_idol"},
        {"克利夫兰","kelifulan"},
        {"克利夫兰偶像","kelifulan_idol"},
        {"金布里","lin"},
        {"彩布里","buli_super"},
        {"列克星敦","liekexingdun"},
        {"黎塞留","lisailiu"},
        {"让巴尔","rangbaer"},
        {"罗恩","luoen"},
        {"罗恩偶像","luoen_idol"},
        {"莫里","moli"},
        {"夕立","xili" },
        {"欧若拉","ouruola"},
        {"逸仙","yixian"},
        {"塔什干","tashigan"},
        {"谢菲尔德偶像","xiefeierde_idol"},
        {"希佩尔偶像","xipeier_idol"},
        {"萨拉托加","salatuojia"},
        {"绊爱","aijiangDD"},
        {"宝多六花","baoduoliuhua"},
        {"新条茜","qian"},
        {"南梦芽","mengya"},

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
