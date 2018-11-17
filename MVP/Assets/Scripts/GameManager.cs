using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public  int money;
    public  int grades;
    public int party;
    public int sleep;
    

    public Text variablesText; // texto desplegando variables 
    public Text partialText; // texto desplegando el parcial 

    private float nextActionTimeVar = 0.0f; // siguiente timer para restar a 
    public float periodVariables = 0.1f;  //   el tiemp asignado para restar 

    private float nextActionTimeParcial = 0.0f;  // siguiente timer para desplegar informacion del parcial 
    public float periodParcial = 0.1f; // el timpo asignado de lo que dura un parcial 

    private bool game = true;
    private bool lost = false;


    public RectTransform mPanelGameOver;
    public Text GameOverText; 
    private bool mGameOver = false; 

    private int parcial = 0;
    // Use this for initialization

    void Start () {
        // inicializo las diferenciales de tiempo para que no haya falsos positivos
        nextActionTimeVar = periodVariables;
        nextActionTimeParcial = periodParcial; 
        SetText(); 
	}
	
	// Update is called once per frame
	void Update () {
        SetText();
        if (game == true)
        {

            


            if (Time.time > nextActionTimeVar && lost == false)
            {
                nextActionTimeVar += periodVariables;
                money--;
                grades--;
                party--;
                sleep--;
                if (money == 0 || grades == 0 || party == 0 || sleep == 0)
                {
                    game = false;
                    lost = true;
                    GameOver(2);
                }

            }




            if (Time.time > nextActionTimeParcial)
            {
                nextActionTimeParcial += periodParcial;
                parcial++;
                if (parcial == 3)
                {

                    game = false;
                    GameOver(1);

                }
                else
                    UnityEngine.Debug.Log( "Parcial: " + parcial);
            }


        }
        
        
    }


   

    void GameOver(int status)
    {
        mPanelGameOver.gameObject.SetActive(true);
        if (status == 1)
        {
            GameOverText.text = "You Graduated !";

        }
        else
            GameOverText.text = "You were expelled";
    }
    void SetText()
    {
        if (game == true){
            variablesText.text = "Money: " + money.ToString() + "/ 100   Grades: " + grades.ToString() + "/100   Party: " + party.ToString() + " / 100   Sleep: " + sleep.ToString() + " / 100";
            partialText.text = "Partial: " + (parcial+1).ToString();
        } 
    }
}
