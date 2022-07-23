using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SelectChara : MonoBehaviour
{

    public GameObject SDObject;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Dropdown>().onValueChanged.AddListener((int index) => dropdowmItemChanged(index));
        CreateDropdowmOptions();
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateDropdowmOptions()
    {
        var thisDropdowm = this.gameObject.GetComponent<Dropdown>();
        thisDropdowm.options.Clear();

        List<string> keyList = DictionaryUtil.getCharaSDAllKeys();
        foreach (string key in keyList)
        {
            Dropdown.OptionData op = new Dropdown.OptionData();
            op.text = key;
            thisDropdowm.options.Add(op);
        }
        Text[] labels = thisDropdowm.transform.Find("Label").GetComponents<Text>();
        foreach (var label in labels)
        {
            label.text = "Ñ¡Ôñ½¢Äï";
        }
    }

    public void dropdowmItemChanged(int index)
    {
        var text = this.gameObject.GetComponent<Dropdown>().options[index].text;
        string SDName = DictionaryUtil.getCharaSDValue(text);

        FileUtil.initSDObject(SDName,SDObject);
    }
}
