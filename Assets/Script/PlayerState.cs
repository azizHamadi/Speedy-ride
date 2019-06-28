using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public float PV { get  ; set; }
    public float Damage { get; set; }

    public PlayerState()
    {
        PV = 100f;
        Damage = 25;
    }

}
