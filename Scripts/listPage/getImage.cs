using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getImage : MonoBehaviour
{
    public string imageName;
    private void Awake()
    {
        this.GetComponent<Image>().sprite = FileUtil.getSprite(imageName);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
