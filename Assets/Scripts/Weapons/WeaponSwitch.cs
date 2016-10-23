using UnityEngine;
using System.Collections;

public class WeaponSwitch : MonoBehaviour 
{ 
     public int currentWeapon;
     public GameObject[] weapons;

     void Start()
    {
        weapons[0].gameObject.SetActive(true);
        weapons[1].gameObject.SetActive(false);
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
        changeWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
        changeWeapon(1);
        }

    }

    public void changeWeapon(int num)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i==num)
                weapons[i].gameObject.SetActive(true);
            else
                weapons[i].gameObject.SetActive(false);
        }
    }
 }

