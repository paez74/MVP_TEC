using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class NPC : MonoBehaviour
{
   
    
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // en caso de seleccionar el personaje rojo 
        if (Input.GetKeyDown("1"))
        {
            
                SceneManager.LoadScene(1);

        } else if (Input.GetKeyDown("2")) // en caso de seleccionar el personaje verde 
        {
           
                SceneManager.LoadScene(0);

        }
    }

    

}
