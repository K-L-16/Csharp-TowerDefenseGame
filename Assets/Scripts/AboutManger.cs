using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this aboutmanger is teel the information of the developer and introduce the game
public class AboutManger : MonoBehaviour
{
    //clikc the back button
    public void OnBackGame()
    {
        SceneManager.LoadScene(0);//back to main
    }
}
