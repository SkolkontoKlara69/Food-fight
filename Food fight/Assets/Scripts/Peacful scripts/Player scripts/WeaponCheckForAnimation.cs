using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCheckForAnimation : MonoBehaviour
{ 

    private Animator playerAnimator;

    [SerializeField]
    private GameObject equipedSwordSlot;
    public string equipedWeapon;
    


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (equipedSwordSlot != null)
        {
            equipedWeapon = equipedSwordSlot.GetComponent<Image>().sprite.name;

            if (equipedWeapon == "None")
            {
                playerAnimator.SetFloat("WeaponEquiped", 0);
            }
            else if (equipedWeapon == "Träslev")
            {
                playerAnimator.SetFloat("WeaponEquiped", 1);

            }
            else if (equipedWeapon == "Klubba")
            {
                playerAnimator.SetFloat("WeaponEquiped", 2);
            }
            else if (equipedWeapon == "Klubba kyckling")
            {
                playerAnimator.SetFloat("WeaponEquiped", 3);
            }
            else if (equipedWeapon == "Bambupinne")
            {
                playerAnimator.SetFloat("WeaponEquiped", 4);
            }
            else if (equipedWeapon == "Svärdsfisk")
            {
                playerAnimator.SetFloat("WeaponEquiped", 5);
            }
            else if (equipedWeapon == "Baguette")
            {
                playerAnimator.SetFloat("WeaponEquiped", 6);
            }
        }
    }
}
