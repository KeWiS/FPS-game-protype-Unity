using UnityEngine;

public class GunFire : MonoBehaviour
{
    //Public variables
    public float smallDamage = 20f;
    public float sniperDamage = 50f;
    public float sniperRange = 1000f;
    public float smallRange = 350f;
    public float smallForce = 25f;
    public float sniperForce = 75f;
    public float smallFireRate = 10f;
    public float sniperFireRate = 0.1f;
    public float nextTimeToFire = 0f;

    //public float bulletSpeed = 100f;

    public GameObject bullet;
    public GameObject impactPrefab;
    //public GameObject smallBulletPos;
    //public GameObject sniperBulletPos;
    
    public Camera gameCamera;

    public WeaponSwitch gun;

    public ParticleSystem smallMuzzleFlash;
    public ParticleSystem sniperMuzzleFlash;
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            if (gun.smallGunDrawed)
            {
                nextTimeToFire = Time.time + 1f / smallFireRate;
                Shoot();
            }
            else
            {
                nextTimeToFire = Time.time + 1f / sniperFireRate;
                Shoot();
            }
        }
	}
    //Shooting gun method
    void Shoot ()
    { 
        RaycastHit hitInfo;
        if (gun.smallGunDrawed)
        {
            smallMuzzleFlash.Play();
            if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hitInfo, smallRange))
            {
                HitTarget target = hitInfo.transform.GetComponent<HitTarget>();
                if(target != null && target.CompareTag("SmallEnemyTarget"))
                {
                    target.TakeDamage(smallDamage);
                }

                if(hitInfo.rigidbody != null)
                {
                    hitInfo.rigidbody.AddForce(-hitInfo.normal * smallForce, ForceMode.Impulse);
                }

                Instantiate(impactPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
        }
        else
        {
            sniperMuzzleFlash.Play();
            if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hitInfo, sniperRange))
            {
                HitTarget target = hitInfo.transform.GetComponent<HitTarget>();
                if (target != null && target.CompareTag("SniperEnemyTarget"))
                {
                    target.TakeDamage(sniperDamage);
                }

                if (hitInfo.rigidbody != null)
                {
                    hitInfo.rigidbody.AddForce(-hitInfo.normal * sniperForce, ForceMode.Impulse);
                }

                Instantiate(impactPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
        }
    }
}
