using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    GameObject SpawnedBullet;
    GameObject gun;
    CharacterController character;
    GameObject bulletPrefab=null;

    public GameObject GetBulletPrefab()
    {
        return bulletPrefab;
    }
    public void SetBulletPrefab(GameObject BulletPrefab)
    {
        bulletPrefab = BulletPrefab; 
    }
    public void FireBullet()
    {
        SpawnBullet();
    }
    void SpawnBullet( )
    {
        SpawnedBullet = Instantiate(bulletPrefab, SetBulletPosition(), gun.transform.GetChild(0).rotation);
        SpawnedBullet.GetComponent<Bullet>().SetFiredFromGun(gun.GetComponent<Gun>());
        ShootBullet();
    }
    void ShootBullet()
    {
        SpawnedBullet.GetComponent<Rigidbody>().AddForce(gun.transform.forward * 20, ForceMode.Impulse);
    }


    Vector3 SetBulletPosition()
    {
        return new Vector3(gun.transform.GetChild(0).position.x,
                            gun.transform.GetChild(0).position.y,
                            gun.transform.GetChild(0).position.z);
    }

  

    public void SetCharacter(CharacterController Character)
    {
        character = Character;
    }
    public GameObject GetCharacter()
    {
        return gun;
    }
    public void SetGun(GameObject Gun)
    {
        gun = Gun;
    }
 
}
