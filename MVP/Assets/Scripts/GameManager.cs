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
    public RawImage mWinImage;
    public RawImage mLoseImage; 
    public Text GameOverText;


    bool midpause = false; 

    // variables para desplegar los cambios de variable 


    private int startMoney;
    private int startGrades;
    private int startParty;
    private int startSleep;

    public RectTransform mPanelStatChange;
    public Text GradesChangeTxt;
    public Text SleepChangeTxt;
    public Text MoneyChangeTxt;
    public Text PartyChangeTxt;
    public Text OverallTxt; 

    private int parcial = 0;
    // Use this for initialization

    void Start () {
        // inicializo las diferenciales de tiempo para que no haya falsos positivos
        nextActionTimeVar = periodVariables;
        nextActionTimeParcial = periodParcial;
        startMoney = money;
        startGrades = grades;
        startParty = party;
        startSleep = sleep; 
        SetText(); 
	}
	
	// Update is called once per frame
	void Update () {
        if (midpause == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                startGrades = grades;
                startMoney = money;
                startSleep = sleep;
                startParty = party;
                GradesChangeTxt.color = Color.green;
                SleepChangeTxt.color = Color.green;
                MoneyChangeTxt.color = Color.green;
                PartyChangeTxt.color = Color.green;
                OverallTxt.color = Color.green;

                game = true;
                nextActionTimeVar += periodVariables;
                nextActionTimeParcial += periodParcial;


                midpause = false;
                
                mPanelStatChange.gameObject.SetActive(false);
            }
        }
        else
        {
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
                    print(game); 
                    nextActionTimeParcial += periodParcial;
                    parcial++;
                    StatChange();
                    if (parcial == 3)
                    {

                        game = false;
                        GameOver(1);

                    }
                    else
                    {
                        
                        UnityEngine.Debug.Log("Parcial: " + parcial);
                    }
                }


            }
        }
        
    }

    void StatChange()
    {
        int failed = 0;
        mPanelStatChange.gameObject.SetActive(true);
        if (parcial != 3 && game == true)
        {
            midpause = true;

           
            
            GradesChangeTxt.text = (grades - startGrades).ToString();
            SleepChangeTxt.text = (sleep - startSleep).ToString();
            MoneyChangeTxt.text = (money - startMoney).ToString();
            PartyChangeTxt.text = (party - startParty).ToString();

            if (grades - startGrades < 0)
            {
                failed++;
                GradesChangeTxt.color = Color.red;
            }
            if (sleep - startSleep < 0)
            {
                failed++;
                SleepChangeTxt.color = Color.red;
            }
            if (money - startMoney < 0)
            {
                failed++;
                MoneyChangeTxt.color = Color.red;
            }
            if (party - startParty < 0)
            {
                failed++;
                PartyChangeTxt.color = Color.red;
            }
        }else
        {
            GradesChangeTxt.text = grades.ToString();
            SleepChangeTxt.text = sleep.ToString();
            MoneyChangeTxt.text = money.ToString();
            PartyChangeTxt.text = party.ToString();

            if (grades < 70)
            {
                failed++;
                GradesChangeTxt.color = Color.red;
            }
            if (sleep  < 70)
            {
                failed++;
                SleepChangeTxt.color = Color.red;
            }
            if (money  < 70)
            {
                failed++;
                MoneyChangeTxt.color = Color.red;
            }
            if (party < 70)
            {
                failed++;
                PartyChangeTxt.color = Color.red;
            }
        }

        if (failed == 0) OverallTxt.text = "Perfect";
        else if (failed < 3) OverallTxt.text = "Good";
        else if (failed > 3) {
            OverallTxt.text = "Bad";
            OverallTxt.color = Color.red; 
            }

      

    }
   

    void GameOver(int status)
    {
        mPanelGameOver.gameObject.SetActive(true);

        if (status == 1)
        {
            mWinImage.gameObject.SetActive(true);
            GameOverText.text = "You Graduated !";


        }
        else
        {
            StatChange();
            mLoseImage.gameObject.SetActive(true);
            GameOverText.text = "You were expelled";
        }
        
    }
    void SetText()
    {
        if (game == true){
            variablesText.text = "Money: " + money.ToString() + "/ 100   Grades: " + grades.ToString() + "/100   Party: " + party.ToString() + " / 100   Sleep: " + sleep.ToString() + " / 100";
            partialText.text = "Partial: " + (parcial+1).ToString();
        } 
    }
}
