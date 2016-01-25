using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class g_DiceResults : MonoBehaviour {

    public Text results;
    int die_One;
    int die_Two;
    int die_Three;
    int die_Four;
    int die_Five;
    int die_Six;

    string one;
    string two;
    string three;
    string four;
    string five;
    string six;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

        one = "One has been rolled " + die_One + " times.";
        two = "Two has been rolled " + die_Two + " times.";
        three = "Three has been rolled " + die_Three + " times.";
        four = "Four has been rolled " + die_Four + " times.";
        five = "Five has been rolled " + die_Five + " times.";
        six = "Six has been rolled " + die_Six + " times.";
        results.text = one + "\n" + two + "\n" + three + "\n" + four + "\n" + five + "\n" + six;
    }

    public void DiceCountHolder(int diceRoll)
    {
        if (diceRoll == 1)
        {
            die_One++;
        }
        if (diceRoll == 2)
        {
            die_Two++;
        }
        if (diceRoll == 3)
        {
            die_Three++;
        }
        if (diceRoll == 4)
        {
            die_Four++;
        }
        if (diceRoll == 5)
        {
            die_Five++;
        }
        if (diceRoll == 6)
        {
            die_Six++;
        }
        
    }
}
