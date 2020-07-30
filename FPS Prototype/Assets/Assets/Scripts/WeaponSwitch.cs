using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    //Public variables
    public GameObject smallGun;
    public GameObject sniperRifle;
    //Private variables
    bool smallGunDrawed = true;
	// Update is called once per frame
	void Update ()
    {
        //Checking if player pressed Q key
		if(Input.GetKeyDown(KeyCode.Q))
        {
            //Checking if small gun is drawed, first is true
            if(smallGunDrawed)
            {
                //Changing weapon to sniper rifle
                smallGun.SetActive(false);
                sniperRifle.SetActive(true);
                smallGunDrawed = false;
            }
            else
            {
                //Changing weapon to small gun
                sniperRifle.SetActive(false);
                smallGun.SetActive(true);
                smallGunDrawed = true;
            }
        }
	}
}
