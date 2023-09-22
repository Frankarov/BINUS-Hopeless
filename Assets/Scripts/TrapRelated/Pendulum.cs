using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{

    public Rigidbody2D rigidBody2D;
    public HingeJoint2D hingeJoint2D;
    public GameObject triggerPendulum;
    public float leftPush;
    public float rightPush;
    public float velocityThreshold;
    public float offMotorFirst;
    public float intervalMotor;
    public float timeMotor;


    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        hingeJoint2D = GetComponent<HingeJoint2D>();

    }


    public void Swing()
    {
        motorFunction();
        triggerPendulum.SetActive(false);

        InvokeRepeating("motorFunction",timeMotor,intervalMotor);
    }

    private void motorFunction()
    {
        motorEnabled();
        StartCoroutine(motorDisabled());
    }

    private void motorEnabled()
    {
        hingeJoint2D.useMotor = true;
    }


    private IEnumerator motorDisabled()
    {
        Debug.Log("Motordisabled");
        yield return new WaitForSeconds(offMotorFirst);
        hingeJoint2D.useMotor = false;
    }



}
