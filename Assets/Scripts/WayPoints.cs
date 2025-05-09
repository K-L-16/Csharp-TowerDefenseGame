using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//waypoints-- the road of the enemy
public class WayPoints : MonoBehaviour
{
    public static Transform[] positions;

    //update the posiont of the ememy
    private void Awake()
    {
        positions = new Transform[transform.childCount];
        for(int i = 0; i< positions.Length; i++)
        {
            positions[i] = transform.GetChild(i);//add the position in the list
        }
    }
}
