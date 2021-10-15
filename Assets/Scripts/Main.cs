using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("level 1");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Setting()
    {
        mainPanel.SetActive(false);
        settingPanel.SetActive(true);
    }
    public void Back()
    {
        mainPanel.SetActive(true);
        settingPanel.SetActive(false);
    }
}
