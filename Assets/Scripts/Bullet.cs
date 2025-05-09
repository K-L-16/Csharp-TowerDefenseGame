using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Butllet-- this is the bullet clas
public class Bullet : MonoBehaviour
{
    public int damage = 50;//the bullet damage

    public float speed = 20;//the speed of the  bullet

    public GameObject explosionEffectPrefab;//the explosion effect

    private Transform target;//target --follow the target
    
    //settarget,find the enemy
    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }


    // Update is called once per frame
    void Update()
    {
        if(target == null)//if no target in the rang or the the target alreaady die
        {
            Die();
            return;//return stop run the rest of the prog
        }

        transform.LookAt(target.position);//update hte Look at positon(for misssile)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);//up date the posioton
    }

    //if the taret is in the etrigger 
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "enemy" ) //check if the enemy is tag-- enemy
        {
                col.GetComponent<Enemy1>().TakeDamage(damage);//call for enemy-take damage function

                Die(); //destroy the bullet
        }
    }

    //destory the bullet
    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);//show effect 
        Destroy(effect, 1);//delay for 1 second
        Destroy(this.gameObject);//destory

    }
}
