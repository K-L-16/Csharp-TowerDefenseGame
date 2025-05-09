using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//gamemanger--manage the game
public class GameManger : MonoBehaviour
{
    public GameObject EndUI;//end UI

    public Text endMassage;//end Massage

    public static GameManger instance;//this class

    private EnemySpawner enemySpawner; //enemyspawner

    //initialize
    private void Awake()
    {
        instance = this;//initialize
        enemySpawner = GetComponent<EnemySpawner>();//call the spawner to stop enerate the enmey
    }

    //win the game
    public void Win()
    {
        EndUI.SetActive(true);
        endMassage.text = "W I N";
    }
    
    //lost the game
    public void Lost()
    {
        enemySpawner.stop();//stop generate the enemy
        EndUI.SetActive(true );
        endMassage.text = "Failed ";
    }

    //on button replay
    public void OnButtonReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//re load the scene
    }

    //back to main scene
    public void OnButtonMenu()
    {
        SceneManager.LoadScene(0);//back to main
    }
}
