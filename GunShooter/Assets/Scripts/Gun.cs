using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : BulletSpawner
{
    public enum GunType { none, ShotGun, SniperRifle, MachineGun };
    //GameObject bulletSpawnedRb;
   // GameObject bulletPrefab;

   // int bulletForce = 50;
    int bulletLimit;
    int zoomRange;

    string gunId;
    string gunName;
    string gunType;
    int gunPower;
    float gunThrowPower;


    public void GunInitializer(string GunID, string GunName, GunType type, int GunPower, float GunThrowPower)
    {
        gunId = GunID;
        gunName = GunName;
        gunPower = GunPower;
        gunThrowPower = GunThrowPower;
        gunType = "Gun";
       
    }
    public float GetGunThrowPower()
    {
        return gunThrowPower;
    }
    public int GetGunPower()
    {
        return gunPower;
    }
    public string GetGunId()
    {
        return gunId;
    }
    public string GetGunName()
    {
        return gunName;
    }

    public string GetGunType()
    {
        return gunType;
    }
    //public virtual void UseWeapon()
    //{
    //    Shoot();
    //}

    //public void SetActiveBullet(GameObject bulletRb)
    //{
    //    bulletSpawnedRb = bulletRb;
    //}

    public virtual void Bullets()
    {
        SetBulletLimit(6);
    }
    public void SetBulletLimit(int bLimit)
    {
        bulletLimit = bLimit;
    }

    //public virtual void Shoot()
    //{
    //    // shoot according to bullet limit.
    //    //simple shoot with max 6 bullets.
    //    if (bulletLimit > 0)
    //    {
    //        Fire();
    //        bulletLimit--;
    //    }
    //    else
    //    {
    //        //on exceed with limit it should reload its cartrige
    //        SetWeapon();
    //        Bullets();
    //    }

    //}

    public virtual void Fire()
    {
       
    }

    public void SetWeapon()
    {
        CartridgeReload();
    }


    public virtual void CartridgeReload()
    {
        //gun cartrige reload method
        Bullets();
    }


    public virtual void Range()
    {
        RearSight(100);
    }

    public virtual void RearSight(int zoom)
    {
        zoomRange = zoom;
        //zoom area according to zoom range.
    }

}
