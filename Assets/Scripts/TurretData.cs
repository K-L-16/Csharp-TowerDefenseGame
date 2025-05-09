using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//turret data
[System.Serializable]//let this class can be see in the inspector
public class TurretData 
{
    public GameObject turretPrefab;//the prefab of turret
    public int cost;//the cost of one turret
    public GameObject turretUpgradePrefeb;
    public int costUpgrade;//the cost of the upgrade the turret
    public TurretType type;//the type of the turrent 
}

public enum TurretType
{
    LaserTurret,//laser 
    MissileTurret,//missile
    StandardTurret//standard
}
