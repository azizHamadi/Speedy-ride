using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerState
{
    public event Action MonEvent;


    public bool PlayerDead  { get { return PV <= 0f; } }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerTombe();

        if (MonEvent != null && !PlayerDead)
        {
            MonEvent();
        }
        
    }

    public void PlayerTombe()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if(pos.y <= 0.0f)
        {
            RecevoirDegat(Mathf.Infinity);
        }
    }

    public void RecevoirDegat(float degat)
    {
        PV -= degat;
    }
}
