using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : Gun
{
    bool once=true;
    public GameObject bombPrefab;
    public int health;
    SpawnManager spawnManager;
    public GameObject activatedGun=null;



    // Start is called before the first frame update
    void Start()
    {
        
        
        once = true;
    }

    // Update is called once per frame
    void Update()
    {
        Die();
        
    }


    public virtual void AttackByGun()
    {
        GetBomb();
    }
    public void GetBomb()
    {
        
        GetActivatedGun().GetComponent<Gun>().Fire();
    }

    public void SetSpawnManager(SpawnManager spawnManagerref)
    {
        spawnManager = spawnManagerref;
    }

    public void FireBomb()
    {
        this.GetComponent<CharacterController>().ThrowBomb();
    }
    public void SetHealth(int Health)
    {
        health=Health;
    }
    public int GetHealth()
    {
        return health;
    }

    public void GetDamage(int damageByPower)
    {
        this.health -= damageByPower;
        if (health < 0)
            DieByHit();
    }

    void DieByHit()
    {
        HideMe();
        if (this.CompareTag("Enemy"))
            StartCoroutine(EnemySpawn());
        
    }

    void HideMe()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;

    }
    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(3);
        if (once)
        {
            EnemySpawning();
            once = false;
        }
    }

    void EnemySpawning()
    {
        spawnManager.SpawnEnemy(System.Array.IndexOf(spawnManager.spawnPositions, this.gameObject.transform.parent.transform));
        Invoke(nameof(DestroyMe), 2f);
    }
    public virtual void ThrowBomb()
    {


    }

   

    public void SetActivatedGun(GameObject activeGun)
    {
        activatedGun = activeGun;
    }
    public GameObject GetActivatedGun()
    {
        return activatedGun;
    }

  

    void Die()
    {
        if (once)
        {
            if (transform.position.y < -5)
                DestroyMe();
        }
    }

    void DestroyMe()
    {
        //int i = camera.target.IndexOf(this.gameObject.transform);
        //camera.target.RemoveAt(i);

        Destroy(gameObject);
    }

}
