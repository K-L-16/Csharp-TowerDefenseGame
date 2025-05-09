using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//infomation mangager
public class InfoManger : MonoBehaviour
{
    //click the backbutton event
   public void OnBackbutton()
    {
        SceneManager.LoadScene(0);//back to main scene
    }
}
