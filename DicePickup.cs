using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DicePickup : MonoBehaviour {


    //This is a list that will hold all the dice in play
    List<GameObject> die = new List<GameObject>();  
    

    //========================================
    void Start()
    //========================================
    {
        die.AddRange(GameObject.FindGameObjectsWithTag("Die"));     //This adds ALL dice with the "Die" tag to the list

        //This sets the position of each element in the die list.  This is currently set up for five die.
        die[0].transform.position = new Vector3(0, 10, 0);
        die[1].transform.position = new Vector3(3, 10, 0);
        die[2].transform.position = new Vector3(-3, 10, 0);
        die[3].transform.position = new Vector3(0, 10, -3);
        die[4].transform.position = new Vector3(0, 10,  3);
    }


    //========================================
    public void Reroll()
    //========================================
    {
        die[0].transform.position = new Vector3(0, 10, 0);
        die[1].transform.position = new Vector3(3, 10, 0);
        die[2].transform.position = new Vector3(-3, 10, 0);
        die[3].transform.position = new Vector3(0, 10, -3);
        die[4].transform.position = new Vector3(0, 10, 3);

        //For each item in the die list, reset the call to add torque
        foreach (GameObject dice in die)
        {
            g_DiceTorque dt;
            dt = dice.GetComponent<g_DiceTorque>();
            dt.addTorque = false;
            dt.timeMarker = Time.time + dt.timeToTorque;
            dt.RandomGenerator();
            dt.check = false;
        }
    }
}
