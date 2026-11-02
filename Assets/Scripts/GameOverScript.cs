using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public PlayerScript player;
    //This script controls what happens on the Game Over screen
    //Currently, the only option is for the player to hit 'Space' and restart the game
    
    //Every frame, we check for player inputs
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game Over")
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            //If the player hit space. . .
            {
                //Then load the 'Example 3' scene
                SceneManager.LoadScene("Example 3");
            }
                return;
            
        }
       

     
        if (player.Score >= 20)
        {
            //Then load the 'Example 3' scene
            SceneManager.LoadScene("Example 2");
        }
    }
}
