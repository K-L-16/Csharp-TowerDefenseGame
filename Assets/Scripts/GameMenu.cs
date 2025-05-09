using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//gamemenu-- this is the main game mune
public class GameMenu : MonoBehaviour
{
    public void OnStartGame()
    {
        SceneManager.LoadScene(1);//laod choice game level scene
    }

    public void OnExitGame()
    {
        Application.Quit();//quit game
    }

    public void OnAboutGame()
    {
        SceneManager.LoadScene(5);//load about game
    }

    public void OnInfoButton()
    {
        SceneManager.LoadScene(6);//load the turret information scene
    }
   
}
