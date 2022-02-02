using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Gun
{
    public GameObject BulletPrefab;


    private void Start()
    {
       // SetBulletPrefab(BulletPrefab);
    }
    public MachineGun()
    {
        GunInitializer("MG-00102", "Machine Gun", GunType.MachineGun, 120,50);
    }

    override public void Bullets()
    {
        SetBulletLimit(15);
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
        RearSight(160);
    }

    public void AutoFire()
    {

    }
   



}
