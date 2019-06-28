using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetString("level1", "oui");
        PlayerPrefs.SetString("level2", "non");


    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene(4);
        PlayerPrefs.SetString("level2", "oui");
        PlayerPrefs.SetString("level1", "non");

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
