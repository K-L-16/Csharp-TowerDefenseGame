using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//turret-- control the turret attack
public class Turret : MonoBehaviour
{
    private List<GameObject> enemys = new List<GameObject>();//the list of enemy that in the turret rang
    //check if the enemy is in the rang of the turret

    //get the enemy
    private void OnTriggerEnter(Collider col)
    {
        //check if teh enemy is in the rang
        if(col.tag == "enemy")
        {
            enemys.Add(col.gameObject);//add it in the list
        }
    }

    //out of the rang, delete the enemy
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "enemy")
        {
            enemys.Remove(col.gameObject);//add it in the list
        }
    }

    //attack rate turret
    public float attackRateTime = 1;//how many attack in one second

    private float timer = 0;//timer

    public GameObject BulletPrefab;//the bullet

    public Transform firePosition;//the fire position of the turret

    public Transform head;//the head (control the direction of the turret to the enemy)

    public bool useLaser = false;//check the bullet if use laser

    public float damegeRate = 40;//the laser damege(one second 40)

    public LineRenderer laserRenderer;//line laser

    public GameObject LaserEffect;//laser effect

    private void Start()
    {
        timer = attackRateTime;//initialize
    }

    private void Update()
    {
        //update the direction of the head
        if (enemys.Count > 0 && enemys[0] != null)
        {
            Vector3 targetPosition = enemys[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);
        }
        if(!useLaser)//check if not use laser
        {
            //bullet attack
            timer += Time.deltaTime;//add up the time
            if (enemys.Count > 0 && timer >= attackRateTime)//check if enough time and if the number is in the rang
            {
                timer = 0;
                Attack();//attack
            }
        }
        else if(enemys.Count > 0)//laser attack
        {
            if(!laserRenderer.enabled )
            {
                laserRenderer.enabled = true;//laser render is true
            }
            LaserEffect.SetActive(true);
            if (enemys[0] == null)//If all enemy died
            {
                UpdateEnemys();
            }//update the enemy
            if(enemys.Count > 0)
            {
                //show the laser
                laserRenderer.SetPositions(new Vector3[] { firePosition.position, enemys[0].transform.position });
                //attack
                enemys[0].GetComponent<Enemy1>().TakeDamage(damegeRate * Time.deltaTime);
                LaserEffect.transform.position = enemys[0].transform.position;
                //change the direction of the effect
                Vector3 pos = transform.position;//get position
                pos.y = enemys[0].transform.position.y;
                LaserEffect.transform.LookAt(pos);//update the postion
            }//laser attack
        }
        else
        {
            LaserEffect.SetActive(false);
            laserRenderer.enabled = false;
        }
        
        
    }

    //attack
    void Attack()
    {
        //echck if the first enemy is 0
        if (enemys[0] == null)
        {
            UpdateEnemys();
        }
        //check if number of the enumy is 0
        if(enemys.Count > 0)
        {
            GameObject bullet = GameObject.Instantiate(BulletPrefab, firePosition.position, firePosition.rotation);//bullet attack
            bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
        }
        else//no enemy 
        {
            timer = attackRateTime;//reset the attack rate time
        }
      
    }

    //update the enemy in the turret triggle
    void UpdateEnemys()
    {
        List<int> emptyIndex = new List<int>();//a list keep all null enmey
        for(int index = 0; index < enemys.Count; index++)
        {
            if (enemys[index] == null)
            {
                emptyIndex.Add(index);//add the enemy null
            }
        }
        //remove the enemy
        for(int i = 0; i < emptyIndex.Count; i++)
        {
            enemys.RemoveAt(emptyIndex[i]-i);//move all enemy front(remove all the null )
        }
    }
}
