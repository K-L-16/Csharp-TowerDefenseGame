using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//buildmanger-- this is the class that for each mapcube to build the turret
public class BulidManager : MonoBehaviour
{
    //use turret data to keep three value turret
    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretData;

    //curret choose turret(turret need to build)
    private TurretData selectedTurretData;
    //current choice turret(object in the game)
    private MapCube SelectedMapcube;

    public Text moneyText;//money text on the UI

    public Animator moneyAnimator;//the animation

    private int money = 360;//the money initial have 360

    public GameObject upgradeCanvas;//show upfrade canvas 

    public Button button_upgrade;//upgare button

    private float timer = 0;//the timer to add up the money


    //change money in the text_money
    public void ChangeMoney(int change = 0)//defulat is 0
    {
        money += change;//cheng the money
        moneyText.text = "$ " + money;//change text show
    }

    //update the status
    private void Update()
    {
        //if clikc the mouse left button
        if(Input.GetMouseButtonDown(0))
        {
            //check if the mouse pinter is on the UI 
            if(EventSystem.current.IsPointerOverGameObject()==false)
            {
                //if not on the UI
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//ehck the ray of the mouse pointer
                RaycastHit hit;//if the ray hit the Mapcube
                bool isCollider = Physics.Raycast(ray,out hit, 1000, LayerMask.GetMask("MapCube"));
                if(isCollider)//if ray hit the Mapcube
                {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();//egt the hitted mapcube

                    if(selectedTurretData != null && mapCube.turretGo == null)//if no Turret is on the cube
                    {
                        //can build
                        if (money >= selectedTurretData.cost)//check if the money is enough
                        {
                            ChangeMoney(-selectedTurretData.cost);//show the curretn money(minus the money)

                            mapCube.BuildTurret(selectedTurretData);//built the turret
                        }
                        else
                        {
                            //money is not enough
                            moneyAnimator.SetTrigger("Flicker");
                        }
                    }//the do have a turret on the mapcube
                    else if (mapCube.turretGo != null)
                    {
                        //if true noupdage , is false upgrade
                        //check if re-click is the smae mapcube, and the UI is show
                        if (mapCube == SelectedMapcube && upgradeCanvas.activeInHierarchy)
                        {
                            HideUpgradeUI();//hide it
                        }
                        else//didn't show UI, make UI active, and check the isupgrade 
                        {
                            ShowUPgradeUI(mapCube.transform.position, mapCube.isUpgrade);
                        }
                        SelectedMapcube = mapCube;//update the selecredmapcube

                    }//else if 
                }//if
            }//if
        }//if
        timer += Time.deltaTime; //add up the timer
        if (timer > 2.5) 
        { 
            ChangeMoney(2); 
            timer = 0; 
        }//for each 2.5 second the money will add 2
    }

    //on laser selected icon
    public void OnLaserSelected(bool isOn)
    {
        if(isOn)//if the mouse clikc and toggle is on
        {
            selectedTurretData = laserTurretData;//update
        }
    }

    //on missiles selected
    public void OnMissileSelected(bool isOn)
    {
        if (isOn)//if the mouse clikc and toggle is on
        {
            selectedTurretData = missileTurretData;//update
        }
    }

    //on standarselected
    public void OnStandarSelected(bool isOn)
    {
        if (isOn)//if the mouse clikc and toggle is on
        {
            selectedTurretData = standardTurretData;//update
        }
    }

    //show UI gradeUI
    //vector3-- position of the mapcube
    //isdisableupgrade--check if the buttonupgrade could use
    void ShowUPgradeUI(Vector3 pos, bool isDisableUPgrade = false)
    {
        button_upgrade.interactable = !isDisableUPgrade;//check
        upgradeCanvas.SetActive(true);//set to active
        upgradeCanvas.transform.position = pos;//update th epostion
       
    }

    //hide the upgrade UI
    void HideUpgradeUI()
    {
        upgradeCanvas.SetActive(false);
    }

    //if click the Upgrade button
    public void OnUpgradeButtonDown()
    {
        //check if the money is enough
        if(money >= SelectedMapcube.turretData.costUpgrade)
        {
            ChangeMoney(-SelectedMapcube.turretData.costUpgrade);//update the money
            SelectedMapcube.UPgradeTurret();//upgrade the turret
            SelectedMapcube.isUpgrade = true;///////////////////////////reset to it true
        }
        else
        {
            //money is not enough
            moneyAnimator.SetTrigger("Flicker");//show animation
        }
        HideUpgradeUI();//hid UI
    }

    //ondestroy button --desotry the turret and reset the status
    public void OnDestoryButtonDown()
    {
        SelectedMapcube.isUpgrade = false;///////////////////////////////////////resetfalse
        button_upgrade.interactable = true;//set it to true
        SelectedMapcube.DestroyTurret();
        HideUpgradeUI();
    }


}
