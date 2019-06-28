using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class test : MonoBehaviour
{
    private int testRotation = 0;
    public WheelJoint2D frontwheel;
    public WheelJoint2D backwheel;

    JointMotor2D motorFront;

    JointMotor2D motorBack;

    public float speedF;
    public float speedB;

    public float torqueF;
    public float torqueB;


    public bool TractionFront = true;
    public bool TractionBack = true;


    public float carRotationSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0)
        {


            if (TractionFront)
            {
                motorFront.motorSpeed = speedF * -1;
                motorFront.maxMotorTorque = torqueF;
                frontwheel.motor = motorFront;
            }

            if (TractionBack)
            {
                motorBack.motorSpeed = speedF * -1;
                motorBack.maxMotorTorque = torqueF;
                backwheel.motor = motorBack;

            }

        }
        else if (CrossPlatformInputManager.GetAxisRaw("Horizontal") > 0)
        {

            if (TractionFront)
            {
                motorFront.motorSpeed = speedB * -1;
                motorFront.maxMotorTorque = torqueB;
                frontwheel.motor = motorFront;
            }

            if (TractionBack)
            {
                motorBack.motorSpeed = speedB * -1;
                motorBack.maxMotorTorque = torqueB;
                backwheel.motor = motorBack;

            }

        }
        else
        {
            motorBack.motorSpeed = 0;
            motorBack.maxMotorTorque = 0;
            motorFront.motorSpeed = 0;
            motorFront.maxMotorTorque = 0;
            backwheel.motor = motorBack;
            frontwheel.motor = motorFront;
            backwheel.useMotor = false;
            frontwheel.useMotor = false;

        }




        if (CrossPlatformInputManager.GetAxisRaw("Vertical") > 0)
        {
            testRotation = 1;
            GetComponent<Rigidbody2D>().AddTorque(carRotationSpeed );

        }
        else if (CrossPlatformInputManager.GetAxisRaw("Vertical") < 0)
        {
            testRotation = -1;
            GetComponent<Rigidbody2D>().AddTorque(carRotationSpeed * -1);

        }
        else
        {
            if(testRotation == -1)
                GetComponent<Rigidbody2D>().AddTorque(0);
            else if(testRotation == 1)
                GetComponent<Rigidbody2D>().AddTorque(0);


        }

    }
}
