using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {

    private GameObject triggeringNPC;
    private bool triggering;
    public GameObject npcText;
    private int triggerScene; 

    void Start()
    {

    }
    void Update()
    {
        if (triggering)
        {
            npcText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                /*if (Input.GetKeyDown("1"))
                {

                    SceneManager.LoadScene(1);

                }*/
                print(triggerScene);
                Destroy(triggeringNPC);
                triggering = false; 
            }

        }
        else
        {
            npcText.SetActive(false);
        }

    }

    // cuando el objeto esta chocando con el NPC
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC" || other.tag == "LabNPC")
        {
            if (other.tag == "LabNPC") triggerScene = 1; else triggerScene = 2; 
            triggering = true;
            triggeringNPC = other.gameObject; 
        }
    }

    // cuando el jugador no esta chocando con el NPC
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "NPC")
        {
            triggering = false;
            triggeringNPC = null; 
        }
    }


}
