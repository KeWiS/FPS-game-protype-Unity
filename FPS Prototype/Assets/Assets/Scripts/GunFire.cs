using UnityEngine;

public class GunFire : MonoBehaviour
{
    //Public variables
    public GameObject impactPrefab;
    
    public Camera gameCamera;

    public WeaponSwitch gun;

    public ParticleSystem smallMuzzleFlash;
    public ParticleSystem sniperMuzzleFlash;

    public AudioClip pistolSound;
    public AudioClip sniperSound;

    public GameManager gameManager;


    public float smallDamage = 20f;
    public float sniperDamage = 50f;
    public float sniperRange = 1000f;
    public float smallRange = 350f;
    public float smallForce = 25f;
    public float sniperForce = 75f;
    public float smallFireRate = 10f;

    //Private variables
    AudioSource pistol;
    AudioSource sniper;

    float nextTimeToFire = 0f;
    
    //Use this for initialization
    void Start()
    {
        //Assigning GameManager component to gameManager variable
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //
        pistol = GetComponent<AudioSource>();
        sniper = GetComponent<AudioSource>();
    }

    //Update is called once per frame
    void Update ()
    {
        //Checking if game is still running
        if (!gameManager.gameOver)
        {
            //Checking if player pressed fire mouse button
            if (Input.GetButtonDown("Fire1"))
            {
                //Checking which gun is in player's hands
                if (gun.smallGunDrawed && Time.time >= nextTimeToFire)
                {
                    //Calculating next shooting time for handgun
                    nextTimeToFire = Time.time + 1f / smallFireRate;
                    //Calling shooting method
                    Shoot();
                }
                else if(Time.time >= nextTimeToFire)
                {
                    //Calculating next shooting time for sniper rifle
                    nextTimeToFire = Time.time + 1f;
                    //Calling shooting method
                    Shoot();
                }
            }
        }
	}
    //Shooting gun method
    void Shoot ()
    { 
        //Declaring raycast info variable
        RaycastHit hitInfo;
        //Checking if pistol is in player's hands
        if (gun.smallGunDrawed)
        {
            //Playing muzzle flash effect
            smallMuzzleFlash.Play();
            //Playing pistol shot sound
            pistol.PlayOneShot(pistolSound, 1.0f);
            //Checking if ray hits something
            if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hitInfo, smallRange))
            {
                //Getting info from hit target
                HitTarget target = hitInfo.transform.GetComponent<HitTarget>();
                //Checking if ray hit small enemy target
                if(target != null && target.CompareTag("SmallEnemyTarget"))
                {
                    //Calling damage taking method
                    target.TakeDamage(smallDamage);
                }
                //Checking if hit target has rigidbody
                if(hitInfo.rigidbody != null)
                {
                    //Applying force to hit target
                    hitInfo.rigidbody.AddForce(-hitInfo.normal * smallForce, ForceMode.Impulse);
                }
                //Playing impact effect
                Instantiate(impactPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
        }
        else
        {
            //Playing muzzle flash effect
            sniperMuzzleFlash.Play();
            //Playing sniper shot sound
            sniper.PlayOneShot(sniperSound, 1.0f);
            //Checking if ray hits something
            if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hitInfo, sniperRange))
            {
                //Getting info from hit target
                HitTarget target = hitInfo.transform.GetComponent<HitTarget>();
                //Checking if ray hit sniper enemy target
                if (target != null && target.CompareTag("SniperEnemyTarget"))
                {
                    //Calling damage taking method
                    target.TakeDamage(sniperDamage);
                }
                //Checking if hit target has rigidbody
                if (hitInfo.rigidbody != null)
                {
                    //Applying force to hit target
                    hitInfo.rigidbody.AddForce(-hitInfo.normal * sniperForce, ForceMode.Impulse);
                }
                //Playing impact effect
                Instantiate(impactPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
        }
    }
}
