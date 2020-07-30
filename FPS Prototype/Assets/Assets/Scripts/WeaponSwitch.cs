using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    //Public variables
    public GameObject smallGun;
    public GameObject sniperRifle;
    public GameObject smallGunCrosshair;
    public GameObject sniperRifleCrosshair;

    public GameManager gameManager;

    public bool smallGunDrawed = true;

    //Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //Update is called once per frame
    void Update ()
    {
        if (!gameManager.gameOver)
        {
            //Checking if player pressed Q key
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GunSwitch();
            }
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
            sniperRifleCrosshair.SetActive(true);
        }
        else
        {
            //Changing weapon to small gun
            sniperRifle.SetActive(false);
            smallGun.SetActive(true);
            smallGunDrawed = true;
            smallGunCrosshair.SetActive(true);
            sniperRifleCrosshair.SetActive(false);
        }
    }
}
