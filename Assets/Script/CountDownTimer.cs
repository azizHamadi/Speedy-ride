using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    float currentTimer = 0f;
    float startingTime = 45f;
    [SerializeField] TextMeshProUGUI timer;

    // Start is called before the first frame update
    void Start()
    {
        currentTimer = startingTime;
    }

    public void btn()
    {
        Debug.Log("5edmet l'button");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Car.pause)
        {
            if (currentTimer > 0 && Car.countTimer && !Car.etatSuccess)
            {

                currentTimer -= 1 * Time.deltaTime;

                int minutes = Mathf.FloorToInt(currentTimer / 60f);

                int seconds = Mathf.RoundToInt(currentTimer % 60f);

                string formatedSeconds = seconds.ToString();
                if (seconds == 60)
                {
                    if (minutes > 0)
                        minutes -= 1;
                    seconds = 0;
                }
                if (seconds == 0)
                {
                    minutes = 0;
                }
                if (seconds < 10 && minutes == 0)
                    timer.text = "0" + minutes.ToString() + ":0" + formatedSeconds.ToString();
                else
                    timer.text = "0" + minutes.ToString() + ":" + formatedSeconds.ToString();
                if(PlayerPrefs.GetString("level1").Equals("oui"))
                    PlayerPrefs.SetInt("score1", seconds);
                else
                    PlayerPrefs.SetInt("score2", seconds);
                if (seconds == 0 && minutes == 0)
                    Car.countTimer = false; 
            }
            else
            {
                var score = 0;
                if (PlayerPrefs.GetString("level1").Equals("oui"))
                    score = PlayerPrefs.GetInt("score1");
                else
                    score = PlayerPrefs.GetInt("score2");
                if (!Car.etatSuccess && !Car.countTimer)
                    Car.etat = false;
            }
        }
        
    }

    public void pause()
    {
        Car.pause = true;
        Car.pauseEtat = true;
    }

    public void Exit()
    {
        Car.pause = false;
        Car.pauseEtat = false;
        SceneManager.LoadScene(0);
    }

    public void resume()
    {
        Car.pauseEtat = false;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
