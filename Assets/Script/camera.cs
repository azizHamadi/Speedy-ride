using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;

    [SerializeField]
    public GameObject player;       //Public variable to store a reference to the player game object

    [SerializeField]
    public float xMin;       //Public variable to store a reference to the player game object
    [SerializeField]
    public float xMax;       //Public variable to store a reference to the player game object
    [SerializeField]
    public float xFin;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    private void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
        player = Car.player;
        Car.etatSuccess = false; 
        Car.countTimer = true;
        offset = transform.position - player.transform.position;
    }

    public void affichage()
    {
        Debug.Log("c bon ");
    }

    // LateUpdate is called after Update each frame
    void Update()
    {

        if(player == null)
        {
            return;
        }
        Vector3 a = player.transform.position;
        a.y = 0.9f;
        if (a.x < xMin)
            a.x = xMin;
        if (a.x > xMax)
            a.x = xMax;
        
        if (player.transform.position.x >= xFin) { 
            Car.etatSuccess = true;
            Debug.Log("wseeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeel");
        }
        if (player.transform.rotation.z > 0.6 || player.transform.rotation.z < -0.65)
            Car.countTimer = false;
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = a + offset ;
        
    }
}



