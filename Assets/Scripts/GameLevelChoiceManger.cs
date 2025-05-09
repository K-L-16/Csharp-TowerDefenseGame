using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//game level- choice
public class GameLevelChoiceManger : MonoBehaviour
{
    //foreress
    public void OnForestButton()
    {
        SceneManager.LoadScene(2);
    }

    //snow
    public void OnSnowButton()
    {
        SceneManager.LoadScene(3);
    }

    //planet
    public void OnPlanetButton()
    {
        SceneManager.LoadScene(4);
    }

    //back
    public void OnBackButton()
    {
        SceneManager.LoadScene(0);
    }
}
