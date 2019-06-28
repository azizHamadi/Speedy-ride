using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   public void Quit()
    {
        PlayerPrefs.SetString("level1", "non");
        PlayerPrefs.SetString("level2", "non");
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        Car.countTimer = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
