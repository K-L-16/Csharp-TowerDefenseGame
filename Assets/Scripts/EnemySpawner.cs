using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

//enemyspawner-- generate the enemy
public class EnemySpawner : MonoBehaviour
{
    public static int CountEnemyAlive = 0;//the alive number of one wave

    public Wave[] waves;//the number of the waves
    public Transform START;//the start generate posiotion
    public float waverate = 1;//for each wave , interval is 3 seconds
    private Coroutine coroutine;//coroutine
    public Text wave_text;//the wave text
    // Start is called before the first frame update
    void Start()
    {
        coroutine = StartCoroutine(enemyspawner());//update the startcoroutine
    }

    //stop generate the enemy
    public void stop()
    {
        StopCoroutine(coroutine);//stop the function
    }
    //Ienumerator
    IEnumerator enemyspawner()
    {
        //wait 5 seconds before generate
        yield return new WaitForSeconds(5);
        //for each wave
        for(int waveIndex = 0; waveIndex < waves.Length; waveIndex++)
        {
            Wave wave = waves[waveIndex];//this wave is equal the waves[index]
            wave_text.text =  "Wave " + (waveIndex+1);//update the text
            for (int i = 0; i < wave.count;i++)
            {
                //start one
                GameObject.Instantiate(wave.enemyPrefab, START.position, Quaternion.identity);//generate the object
                CountEnemyAlive++;//add up the enemy
                if(i!= wave.count-1)
                {
                    yield return new WaitForSeconds(wave.rate);
                }
            }
            //check if the alive number of tthis wave is0
            while(CountEnemyAlive > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waverate);//for each wave end wait for 3 seconds

        }
        //check if all enemy died
        while((CountEnemyAlive ) > 0)
        {
            yield return 0;//if the enemy alive is 
        }
        GameManger.instance.Win();
    }
}
