using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//exitbutton
public class ExitButton : MonoBehaviour
{


    //click the exit button
    public void exit()
    {
        SceneManager.LoadScene(0);//uplaod the scene
    }
}
