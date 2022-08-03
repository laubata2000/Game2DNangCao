using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject instructionPanel;
    public Button playButton, menuButton, quitButton;
    public Text tieude;
    public Slider slider;

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
        playButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        slider.gameObject.SetActive(false);


    }

    public void closeInstruction()
    {
        instructionPanel.SetActive(false);
        playButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        slider.gameObject.SetActive(false);

    }
}
