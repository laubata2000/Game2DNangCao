using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject instructionPanel;
    public Button settingButton, replayButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instructionMenu()
    {
        instructionPanel.SetActive(true);
        settingButton.gameObject.SetActive(true);
        replayButton.gameObject.SetActive(true);
        


    }
}
