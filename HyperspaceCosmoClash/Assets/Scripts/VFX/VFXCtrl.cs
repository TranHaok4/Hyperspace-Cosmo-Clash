using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXCtrl : HaroMonoBehaviour
{
    public string[] vfxNames = { "Explosion", "Common", "Spawn","BulletImpact","ShieldImpact" };
    public int selectedVFXNameIndex;


    [HideInInspector] public ExplosionVFXName.ExplosionVFXNameEnum explosionVFXName;
    [HideInInspector] public CommonVFXName.CommonVFXNameEnum commonVFXName;
    [HideInInspector] public SpawnVFXName.SpawnVFXNameEnum spawnVFXName;
    [HideInInspector] public BulletImpactVFXName.BulletImpactVFXNameEnum bulletImpactVFXName;
    [HideInInspector] public ShieldImpactVFXName.ShieldImpactVFXNameEnum shieldImpactImpactVFXName;


    private void OnValidate()
    {
        string newName = "";
        switch (selectedVFXNameIndex)
        {
            case 0:
                newName = explosionVFXName.ToString();
                break;
            case 1:
                newName = commonVFXName.ToString();
                break;
            case 2:
                newName = spawnVFXName.ToString();
                break;
            case 3:
                newName = bulletImpactVFXName.ToString();
                break;
            case 4:
                newName = shieldImpactImpactVFXName.ToString();
                break;
            default:
                break;
        }

        //Debug.Log(newName);
        transform.name = newName;
    }

}
