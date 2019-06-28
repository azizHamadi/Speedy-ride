using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnnerScript : MonoBehaviour
{
    public GameObject cloud;
    public float delai = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCloud", 0f, delai);

    }

    // Update is called once per frame
    void SpawnCloud()
    {
        Instantiate(cloud);
    }
}
