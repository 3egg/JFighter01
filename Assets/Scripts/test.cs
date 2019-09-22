using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var image1Btn = image1.GetComponentInChildren<Button>(true);
        var image2Btn = image2.GetComponentInChildren<Button>(true);
        print(image1Btn.GetComponentInChildren<Text>().text);
        print(image2Btn.GetComponentInChildren<Text>().text);
        
        print(image1Btn.tag);
        print(image2Btn.tag);
    }
}
