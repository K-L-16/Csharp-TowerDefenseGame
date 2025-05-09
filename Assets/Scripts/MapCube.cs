using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;

//Mapcube -- this is the gamoject in the game(Mapcube)
public class MapCube : MonoBehaviour
{
    [HideInInspector]//hide the show
    public GameObject turretGo;//if turret is on cube
    [HideInInspector]//hide the show
    public TurretData turretData;//turret data
    [HideInInspector]//hide the show
    public bool isUpgrade = false;// is the turret is upgrade(default is false)

    public GameObject buildEffects;//the build turret effect

    private Renderer renderer;//the color change

    private int DestroyBouns = 20;//for each destory turret, get $ 20 back

    private void Start()
    {
        renderer = GetComponent<Renderer>();//get renderer
    }

    //build turret
    //turretdate-- get turret data ffrom turretdata class
    public void BuildTurret(TurretData turretData)
    {
        this.turretData = turretData;//keeep the turret data 
        isUpgrade = false;//set the is upgrade is false
        turretGo = GameObject.Instantiate(turretData.turretPrefab,transform.position, Quaternion.identity);//instantiate
        GameObject effect = GameObject.Instantiate(buildEffects,transform.position, Quaternion.identity);//the build effect
        Destroy(effect, 1.5f);//destory the object
    }

    //upgrade the turret
    public void UPgradeTurret()
    {
        //check again for turret 
        if (isUpgrade)
        {
            return;
        }
        Destroy(turretGo);//destory the turret current
        isUpgrade = true;
        turretGo = GameObject.Instantiate(turretData.turretUpgradePrefeb, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffects, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);//destory the object
    }

    //destroy the turret
    public void DestroyTurret()
    {
        Destroy(turretGo);//destroy the gameoject
        GameObject.Find("GameManger").GetComponent<BulidManager>().ChangeMoney(DestroyBouns);//add bonus
        isUpgrade = false;//set the is upgrade to false
        turretGo = null;//data to null
        turretData = null;
        GameObject effect = GameObject.Instantiate(buildEffects, transform.position, Quaternion.identity);//destroy effect
        Destroy(effect, 1.5f);//destory the object
    }

    //change the color of tthe mapcube when the mouse is on the mouse
    private void OnMouseEnter()
    {
        //check if the mapcube is null and the mouse is not on the UI 
        if (turretGo == null && !EventSystem.current.IsPointerOverGameObject())
        {
            renderer.material.color = Color.gray;//set the color to gray
        }
    }
    // if the mouse leave the selected mapcube , the mappcube color change to write
    private void OnMouseExit()
    {
        renderer.material.color= Color.white;//back to write
    }

}
