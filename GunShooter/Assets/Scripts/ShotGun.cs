using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun
{
    public GameObject BulletPrefab;

    public ShotGun()
    {
        GunInitializer("SG-00101", "Shot Gun", GunType.ShotGun,40,100);
    }

    override public void Bullets()
    {
        SetBulletLimit(6);
    }

    public override void Fire()
    {
        SetGun(this.gameObject);
        SetBulletPrefab(BulletPrefab);
        FireBullet();
    }

    public override void CartridgeReload()
    {
        //gun cartrige reload method
    }

}
