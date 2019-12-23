using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStart : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject minimap;
    //public GameObject DOC;
    public GameObject mainChar;

    public void GameStart()
    {
        mainPanel.gameObject.SetActive(false);
        minimap.gameObject.SetActive(true);
        //DOC.gameObject.SetActive(false);
        mainChar.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
