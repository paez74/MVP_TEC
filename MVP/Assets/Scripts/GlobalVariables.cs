using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalVariables : MonoBehaviour {

    public  int health;
    public  int grades;
    public int party;
    public int sleep;
    public Text variablesText;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    // Use this for initialization
    void Start () {
        
        SetText(); 
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            health--;
            grades--;
            party--;
            sleep--;

        }
        


        SetText(); 
	}

    void SetText()
    {
        variablesText.text = "Health: " + health.ToString() + "/ 100   Grades: " + grades.ToString() + "/100   Party: " + party.ToString() + " / 100   Sleep: " + sleep.ToString() + " / 100";

    }
}
