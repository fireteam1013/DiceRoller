using UnityEngine;
using System.Collections;
    //This is the script that rolls the die and checks the roll result.
    //This script is added to each die
public class g_DiceTorque : MonoBehaviour {

    GameObject controller;
    g_DiceResults dr;
    Rigidbody rb;
    private float xTorque = 360.0f;
    private float yTorque = 360.0f;
    private float zTorque = 360.0f;

    private float xRandom;
    private float yRandom;
    private float zRandom;

    private int diceCount;
    public bool check;


    //This checks whether to add torque to the die.  Essentially if this does not exist to toggle on/off the die willcontinue to spin ad infinitum.
    public bool addTorque;      

    //These are used to time how long the die gets torque.  For one second (1.0f) the die will spin.
    public float timeToTorque = 1.0f;
    public float timeMarker;



    //========================================
    void Start()
    //========================================
    {
        controller = GameObject.Find("Controller");
        dr = controller.GetComponent<g_DiceResults>();
        rb = GetComponent<Rigidbody>();
        addTorque = false;
        timeMarker = Time.time + timeToTorque;
        RandomGenerator();
    }


    //========================================
    void Update()
    //========================================
    {
        if(rb.velocity == new Vector3(0, 0, 0) && check == false && Time.time > timeMarker)
        {
            DiceCheck();
            check = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            DiceCheck();
            Debug.Log(diceCount);
        }
    }


    //========================================
    void FixedUpdate()
    //========================================
    {
        if (addTorque == false && Time.time < timeMarker)
        {
            rb.AddTorque(new Vector3(xRandom, yRandom, zRandom));
        }  

        if(Time.time >= timeMarker)
        {
            addTorque = true;
        }
    }


    //========================================
    public void RandomGenerator()
    //========================================
    {
        xRandom = Random.Range(-xTorque, xTorque);
        yRandom = Random.Range(-yTorque, yTorque);
        zRandom = Random.Range(-zTorque, yTorque);
    }


    //========================================
    void DiceCheck()
    //========================================
    {
        //Vector3.Dot checks to .2 because in testing there is the rare occurrence where the die may land on it's edge, thus some wiggle room is needed or the result will return 0.
        if (Vector3.Dot(Vector3.up, transform.up) > .2)
        {
            diceCount = 1;
        }
        if (Vector3.Dot(Vector3.up, -transform.up) > .2)
        {
            diceCount = 6;
        }

        if (Vector3.Dot(Vector3.up, -transform.forward) > .2)
        {
            diceCount = 2;
        }
        if (Vector3.Dot(Vector3.up, transform.forward) > .2)
        {
            diceCount = 5;
        }

        if (Vector3.Dot(Vector3.up, transform.right) > .2)
        {
            diceCount = 3;
        }
        if (Vector3.Dot(Vector3.up, -transform.right) > .2)
        {
            diceCount = 4;
        }

        dr.SendMessage("DiceCountHolder", diceCount, SendMessageOptions.DontRequireReceiver);
    }
}
