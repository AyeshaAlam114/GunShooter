using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    public float moveSpeed;
    public float rotationSpeed;
    // public Transform focalPosition;
    public GameObject powerIndicator;
    public GunsFactory gunsFactory;
    Rigidbody playerRb;
    Animator playerAnim;
   
    public int multiBombRange;
    public bool hasPowerUp;


    // Start is called before the first frame update
    void Start()
    {
        hasPowerUp = false;
        SetCharacter(this);
        SetHealth(20);
        playerAnim = gameObject.GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        powerIndicator.SetActive(false);
        this.GetComponent<SphereCollider>().enabled = false;
        gunsFactory.SetPlayer(this);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GetActivatedGun() != null)
            {
                ThrowBomb();
                AttackByGun();
                
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
            this.GetComponent<SphereCollider>().enabled = false;


        SelectGun();



    }
  
    void SelectGun()
    {
        if (Input.GetKeyDown(KeyCode.A))
            gunsFactory.GetGun(GunType.ShotGun);
        if (Input.GetKeyDown(KeyCode.S))
            gunsFactory.GetGun(GunType.SniperRifle);
        if (Input.GetKeyDown(KeyCode.D))
            gunsFactory.GetGun(GunType.MachineGun);

    }
    public override void ThrowBomb()
    {
        //active trigger
        this.GetComponent<SphereCollider>().enabled = true;
    }

    void Movement()
    {
       
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (verticalInput == 0 && horizontalInput == 0)
            playerAnim.SetFloat("Speed_f", 0.1f);
        else
            playerAnim.SetFloat("Speed_f", 0.3f);

        playerRb.AddForce(transform.forward * verticalInput * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);

    }


   

    void ThrowForce(Collider other,float strength)
    {
        Rigidbody enemyRb = other.GetComponent<Rigidbody>();
        Vector3 distFromPlayer = other.transform.position - transform.position;

        enemyRb.AddForce(distFromPlayer * strength, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ThrowForce(other, GetActivatedGun().GetComponent<Gun>().GetGunThrowPower());

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
      
        if(collision.gameObject.CompareTag("Enemy"))
        {
            this.GetDamage(10);
        }
    }

}
