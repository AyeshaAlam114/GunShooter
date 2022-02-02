using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : Gun
{
    public GameObject BulletPrefab;

    public SniperRifle()
    {
        GunInitializer("SNG-38101", "Sniper Rifle", GunType.SniperRifle, 80,75);
    }


    override public void Bullets()
    {
        SetBulletLimit(10);
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

    public override void Range()
    {
        //set zoom range for magnification 
        RearSight(120);
    }
    public void BeamFire()
    {

    }

}
