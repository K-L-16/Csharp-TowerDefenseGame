using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//wave-- for each wave 
//keep each wave enemy generate proproity
[System.Serializable]
public class Wave 
{
    public GameObject enemyPrefab;//the enemyprefab
    public int count; //generate number 
    public float rate;//the rate of the speed generation
}
