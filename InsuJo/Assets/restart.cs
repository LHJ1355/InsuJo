using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour
{
    public GameObject overPanel;
    public GameObject ForInit;
    // Start is called before the first frame update
    public void Restart()
    {
        ForInit.gameObject.SetActive(true);
        overPanel.gameObject.SetActive(false);
        ForInit.GetComponent<move>().init();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
