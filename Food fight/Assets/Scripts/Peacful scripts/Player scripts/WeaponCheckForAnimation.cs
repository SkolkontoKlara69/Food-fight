using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCheckForAnimation : MonoBehaviour
{ 

    private Animator playerAnimator;

    [SerializeField]
    [Tooltip("Ta InventoryCanvas/Equipment/PlayerEquipmentPanel/PlayerEquipmentPanel/CenterPanel/Sword")]
    private GameObject equippedSwordSlot;

    [Tooltip("Ändrar även vad som är WeaponEquiped i Animatorn       Inget = 0, Träslev = 1, Klubba = 2, Klubba Kyckling = 3, Bambupinne = 4, Svärdsfisk = 5, Baguette = 6")]
    public string equippedWeapon;
    


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        equippedSwordSlot = GameObject.FindGameObjectWithTag("EquippedSwordSlot");
}

    // Update is called once per frame
    void Update()
    {
        if (equippedSwordSlot != null)
        {
            if (equippedSwordSlot.GetComponent<Image>().sprite == null)
            {
                playerAnimator.SetInteger("WeaponEquiped", 0);
            }
            else
            { 
                equippedWeapon = equippedSwordSlot.GetComponent<Image>().sprite.name;

                if (equippedWeapon == "Träslev")
                {
                    playerAnimator.SetInteger("WeaponEquiped", 1);

                }
                else if (equippedWeapon == "Klubba")
                {
                    playerAnimator.SetInteger("WeaponEquiped", 2);
                }
                else if (equippedWeapon == "Klubba kyckling")
                {
                    playerAnimator.SetInteger("WeaponEquiped", 3);
                }
                else if (equippedWeapon == "Bambupinne")
                {
                    playerAnimator.SetInteger("WeaponEquiped", 4);
                }
                else if (equippedWeapon == "Svärdsfisk")
                {
                    playerAnimator.SetInteger("WeaponEquiped", 5);
                }
                else if (equippedWeapon == "Baguette")
                {
                    playerAnimator.SetInteger("WeaponEquiped", 6);
                }
            }

        }
    }
}
