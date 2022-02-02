using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsFactory : MonoBehaviour
{
    public List<GameObject> gunsList;
    PlayerController player;
    GameObject spawnedGun;
    public void GetGun(Gun.GunType type)
    {
        switch (type)
        {
            case Gun.GunType.ShotGun:
                InstantiateGun(0);
                break;          
            case Gun.GunType.SniperRifle:
                InstantiateGun(1);
                break;          
            case Gun.GunType.MachineGun:
                InstantiateGun(2);
                break;
            default:
                InstantiateGun(0);
                break;

        }
    }

    public void SetPlayer(PlayerController Player)
    {
        player = Player;
    }

    void DestroyPreviousGun()
    {
        Destroy(spawnedGun);
    }
    void InstantiateGun(int index)
    {
        DestroyPreviousGun();
        spawnedGun =Instantiate(gunsList[index], SetGunPosition(), player.transform.rotation,player.transform);
        player.SetActivatedGun(spawnedGun);
    }

    Vector3 SetGunPosition()
    {
        return player.transform.GetChild(0).position;
    }
}
