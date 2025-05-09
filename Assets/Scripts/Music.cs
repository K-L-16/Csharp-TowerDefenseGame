using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//music -- the BGM control
public class Music : MonoBehaviour
{

    private static Music instance;//is music
    public AudioSource AudioSource;//the audioscorce on gameobject

    //wehen the game is awake 
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);//change scene don;t destory this object

            AudioSource = GetComponent<AudioSource>();

        }
        else
        {
            Destroy(gameObject);//if already have one 
        }
    }



}
