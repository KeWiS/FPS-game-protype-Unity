using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    //Public variables
    public GameObject smallGun;
    public GameObject sniperRifle;
    public GameObject smallGunCrosshair;
    
    public bool smallGunDrawed = true;
	// Update is called once per frame
	void Update ()
    {
        //Checking if player pressed Q key
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GunSwitch();
        }
    }
    //Weapon switching method
    public void GunSwitch ()
    {
        //Checking if small gun is drawed, first is true
        if (smallGunDrawed)
        {
            //Changing weapon to sniper rifle
            smallGun.SetActive(false);
            sniperRifle.SetActive(true);
            smallGunDrawed = false;
            smallGunCrosshair.SetActive(false);
        }
        else
        {
            //Changing weapon to small gun
            sniperRifle.SetActive(false);
            smallGun.SetActive(true);
            smallGunDrawed = true;
            smallGunCrosshair.SetActive(true);
        }
    }
}
