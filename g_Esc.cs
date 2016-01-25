using UnityEngine;
using System.Collections;

    //This script quits the application if Q is pressed.
public class g_Esc : MonoBehaviour {

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))   //IF 'Q' is pressed.
        {
            Application.Quit();                 //Quit the application.
        }
	}
}
