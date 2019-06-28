using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCar : MonoBehaviour
{
    [SerializeField]
    public GameObject MiniCar;

    [SerializeField]
    public GameObject VanCar;

    [SerializeField]
    public GameObject SwatCar;

    [SerializeField]
    public GameObject MustangCar;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Car"))
        {
            if (PlayerPrefs.GetString("Car") == "mini")
            {
                Car.updateCar = false;
                MiniCar.SetActive(true);
                SwatCar.SetActive(false);
                MustangCar.SetActive(false);
                VanCar.SetActive(false);
            }
            else if (PlayerPrefs.GetString("Car") == "mustang")
            {
                Car.updateCar = false;
                MiniCar.SetActive(false);
                SwatCar.SetActive(false);
                MustangCar.SetActive(true);
                VanCar.SetActive(false);
            }
            else if (PlayerPrefs.GetString("Car") == "swat")
            {
                Car.updateCar = false;
                MiniCar.SetActive(false);
                SwatCar.SetActive(true);
                MustangCar.SetActive(false);
                VanCar.SetActive(false);
            }
            else if (PlayerPrefs.GetString("Car") == "van")
            {
                Car.updateCar = false;
                MiniCar.SetActive(false);
                SwatCar.SetActive(false);
                MustangCar.SetActive(false);
                VanCar.SetActive(true);
            }
        }
        Car.player = MiniCar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VanCarAction()
    {
        Car.player = VanCar;
        PlayerPrefs.SetString("Car", "van");
        Debug.Log(Car.player.name);
        Car.updateCar = false;
        MiniCar.SetActive(false);
        SwatCar.SetActive(false);
        MustangCar.SetActive(false);
        VanCar.SetActive(true);
    }

    public void MiniCarAction()
    {
        PlayerPrefs.SetString("Car", "mini");
        MiniCar.SetActive(true);
        SwatCar.SetActive(false);
        MustangCar.SetActive(false);
        VanCar.SetActive(false);
        Car.player = MiniCar;
        Debug.Log(Car.player.name);
        Car.updateCar = false;
    }

    public void MustangCarAction()
    {
        PlayerPrefs.SetString("Car", "mustang");
        MiniCar.SetActive(false);
        SwatCar.SetActive(false);
        MustangCar.SetActive(true);
        VanCar.SetActive(false);
        Car.player = MustangCar;
        Car.updateCar = false;
    }

    public void SwatCarAction()
    {
        PlayerPrefs.SetString("Car", "swat");
        MiniCar.SetActive(false);
        SwatCar.SetActive(true);
        MustangCar.SetActive(false);
        VanCar.SetActive(false);
        Car.player = SwatCar;
        Car.updateCar = false;
    }

    public void MenuAction()
    {
        SceneManager.LoadScene(0);
    }
}
