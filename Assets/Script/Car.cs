using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public class Car : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(this);
        }
        public static bool pause = false;
        public static bool pauseEtat = false;
        public static GameObject player;
        public static bool etat = true;
        public static bool countTimer = true;
        public static bool etatSuccess = false;
        public static bool updateCar = true;

        
    }
}
