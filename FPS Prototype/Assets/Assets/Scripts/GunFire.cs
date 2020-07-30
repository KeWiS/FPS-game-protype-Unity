using UnityEngine;

public class GunFire : MonoBehaviour
{
    //Public variables
    public float damage = 10f;
    public float sniperRange = 1000f;
    public float smallRange = 350f;
    
    public Camera gameCamera;

    public WeaponSwitch gun;
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}
    //Shooting gun method
    void Shoot ()
    {
        RaycastHit hitInfo;
        if (gun.smallGunDrawed)
        {
            if(Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hitInfo, smallRange))
            {
                
            }
        }
        else
        {
            if(Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hitInfo, sniperRange))
            {

            }
        }
    }
}
