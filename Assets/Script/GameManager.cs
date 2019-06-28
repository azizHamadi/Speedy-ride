using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance ?? (instance = new GameObject("GameManager").AddComponent<GameManager>());
            }
        }

    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private GameObject etoile;

    [SerializeField]
    private GameObject etoile2;

    [SerializeField]
    private GameObject etoile3;

    [SerializeField]
    private GameObject pauseGame;

    [SerializeField]
    private GameObject Congratulation;

    [SerializeField]
    public Transform MiniCar;

    [SerializeField]
    public Transform Mustang;

    [SerializeField]
    public Transform swat;

    [SerializeField]
    public Transform van;

    [SerializeField]
    public Transform playerPrefab;

    private Transform playerInstanciate;

    private Player playerScript;

    [SerializeField]
    private Transform SpawnPoint;

    private camera cam;

    private void Awake()
    {
        /*if(instance != null)
        {
            Destroy(gameObject) ;
        }
        instance = this;
        if (Car.updateCar == true) { 
            Car.player = playerPrefab.gameObject;
            Car.updateCar = false;
        }
        else {
            Debug.Log(Car.player.name);
        }*/
        if (!PlayerPrefs.HasKey("level1")) {
            PlayerPrefs.SetString("level1", "non");
            PlayerPrefs.SetInt("score2", 0);
            PlayerPrefs.SetInt("score2", 0);
            PlayerPrefs.SetString("level2", "non");
            PlayerPrefs.SetString("enableLevel2", "non");
        }

        if (PlayerPrefs.HasKey("Car"))
        {
            if(PlayerPrefs.GetString("Car") == "mini")
                playerPrefab = MiniCar;
            else if (PlayerPrefs.GetString("Car") == "mustang")
                playerPrefab = Mustang;
            else if (PlayerPrefs.GetString("Car") == "swat")
                playerPrefab = swat;
            else if (PlayerPrefs.GetString("Car") == "van")
                playerPrefab = van;
        }
        else
        {
            PlayerPrefs.SetString("Car", "mini");
            playerPrefab = MiniCar;
        }

        cam = Camera.main.GetComponent<camera>();
        playerInstanciate = Instantiate(playerPrefab, SpawnPoint.position, Quaternion.identity);
        GameObject playerObj = GameObject.FindWithTag("miniCar");
        Car.player = playerObj;
        Debug.Log(playerObj.name);
        //cam.player = playerObj;
        playerScript = playerInstanciate.GetComponent<Player>();
        cam.affichage();
    }


    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Car.etat = true;
        InstanciatePlayer();
    }

    private void InstanciatePlayer()
    {

    }

    private void PlayerScript_MonEvent()
    {
        Destroy(playerInstanciate.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Car.etat == false)
            EndGame();
        if (Car.etatSuccess == true)
            CongratulationAction();
        if(Car.countTimer == false)
        {
            EndGame();
        }
        if (Car.pause || pauseGame.active)
        { 
            if(Car.pauseEtat)
                pause();
            else
            {
                Car.pause = false;
                pauseGame.SetActive(false);
            }
        }

    }

    private void pause()
    {
        Car.pause = false ;
        pauseGame.SetActive(true);
    }

    private void CongratulationAction()
    {
        if (PlayerPrefs.GetString("level1").Equals("oui"))
        {

            if(PlayerPrefs.GetInt("score1") <= 5)
            {
                etoile.SetActive(true);
                etoile2.SetActive(false);
                etoile3.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("score1") >= 6 && PlayerPrefs.GetInt("score1") <= 8)
            {
                etoile.SetActive(false);
                etoile2.SetActive(true);
                etoile3.SetActive(false);
            }
            else
            {
                PlayerPrefs.SetString("enableLevel2", "oui");
                etoile.SetActive(false);
                etoile2.SetActive(false);
                etoile3.SetActive(true);
            }
            PlayerPrefs.SetString("level1", "non");
        }
        else
        {
            if (PlayerPrefs.GetInt("score2") <= 5)
            {
                etoile.SetActive(true);
                etoile2.SetActive(false);
                etoile3.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("score2") >= 6 && PlayerPrefs.GetInt("score2") <= 8)
            {
                etoile.SetActive(false);
                etoile2.SetActive(true);
                etoile3.SetActive(false);
            }
            else
            {
                etoile.SetActive(false);
                etoile2.SetActive(false);
                etoile3.SetActive(true);
            }
            PlayerPrefs.SetString("level2", "non");
        }
        Congratulation.SetActive(true);
        Car.etatSuccess = false;
    }

    public void EndGame()
    {
        Debug.Log("End Game");
        gameOver.SetActive(true);
        Car.etat = true;
    }
}
