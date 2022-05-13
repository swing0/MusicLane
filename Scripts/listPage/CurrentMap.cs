using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentMap : MonoBehaviour
{

    public string currentFilePathName;


    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
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
