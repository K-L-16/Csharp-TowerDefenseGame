using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//enemy --this class is save the enemy properties
public class Enemy1 : MonoBehaviour
{

    private Transform[] positions;//postions of the object
    private int index = 0;  //the waypoints index
    public float speed = 4f;//the move speed of enemy
    public float hp = 150;//hp
    private float totalHP;//total hp
    public GameObject explosioneffect;//explosion effect
    public Slider hpSlider;//hp slider
    public int Bonus;//the bonus of the enemy

    // Start is called before the first frame update
    void Start()
    {
        positions = WayPoints.positions;//let way point equal to positons
        totalHP = hp;//total hp == current hp

    }

    // Update is called once per frame
    void Update()
    {
        Move();//update the move
    }

    //the enemy move method
    void Move()
    {
        //check if the index is out of the range
        if(index > positions.Length-1) { return; }

        //update the postion of the enemy 1
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
        //update the index of the postion
        if (Vector3.Distance(positions[index].position, transform.position) < 0.2f)
        {
            index++;
        }
        if(index > positions.Length-1)//if readch the end point
        {
            ReachDestination();//if reach the destination 
        }
    }

    //reach tehe end
    void ReachDestination()
    {
        GameManger.instance.Lost();//show lost the g2ame
        GameObject.Destroy(this.gameObject);//destroy the enemy
    }

    //destory yhr enemy 
    private void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;//minus the number of the enemy alive when destory
    }

    //if the bullet hit the enemy
    public void TakeDamage(float damage)
    {
        //if the hp is already less that 0, then return
        if(hp <= 0)
        {
            return;
        }//the enemy is died

        hp -= damage;//minus the hp
        hpSlider.value = (float)hp / totalHP;//update tbe up slider
        //after damage check the hp
        if(hp <= 0 )
        {
            Die();
        }
    }

    //die-- the enemy die
    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosioneffect, transform.position, transform.rotation);//effect of the enemy destroy effect
        Destroy(effect, 1.5f);//destoty the effect in 1.5 seconds
        Destroy(this.gameObject);//destory 
        GameObject.Find("GameManger").GetComponent<BulidManager>().ChangeMoney(Bonus);//add bonus
    }
}
