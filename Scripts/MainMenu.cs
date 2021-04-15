using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //used to switch levels 

public class MainMenu : MonoBehaviour
{
    public void PlayButton () //function to actually hit "PLAY" and enter into the game
    {
        SceneManager.LoadScene("Level 1"); 
    }
    public void QuitButton()  //will quit the game BUT we need a debug lug becuase it wont exit unity properly 
    {
        Debug.Log("Proof Quit is working!"); 
        Application.Quit();  
    }
}
