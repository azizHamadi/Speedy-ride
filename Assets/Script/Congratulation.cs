using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Congratulation : MonoBehaviour
{
    public void Menu()
    {
        Car.etat = false; 
        SceneManager.LoadScene(0);
    }
}
