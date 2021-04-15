using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script goes on the object you're going to pick up.
// You will need to set a tag for the object, currently using "Weapon" and "Magic"


public class WeaponItem : MonoBehaviour
{
    // Creating a private inventory of type Inventory (based on the Inventory script we created).
    // - These classes are apparently automatically public.
    public Inventory inventory;
    // This is the graphics for the game object.
    // Created Unity-side.
    public GameObject itemButton;
    public string weaponName;
    public float weaponDamage;
    public float weaponAttackCooldown;
    public float weaponRange;    

    private void Start()
    {
        Debug.Log(name + " has been created!");
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the object that the pickup collides with has the "Player" tag
        // - Check the pickup tag, and store them in the correct item slot/inventory.
        if(other.CompareTag("Player"))
        {
            Debug.Log("I hit the player!");
            if (!inventory.weaponIsFull)
            {
                Debug.Log("Made it here!");
                if (gameObject.tag == "Weapon")
                {
                    // Create the weapon ui component centered on the weapon slot. False world position.
                    // - Then destroy this pickup from the world, and set the slot to full.
                    Instantiate(itemButton, inventory.weaponSlot.transform, false);
                    Transform parent = other.transform.GetChild(3);
                    transform.SetParent(parent);
                    transform.position = parent.position;
                    transform.rotation = parent.rotation * new Quaternion(-150,-90,0,0);
                    StartCoroutine(Wait());
                }
            }
            else if (inventory.weaponIsFull == true)
            {
                
                
            }
        }
    }

    public void DropWeapon(Vector3 location)
    {
        inventory.equippedWeapon.transform.SetParent(null);
        inventory.equippedWeapon.transform.position = new Vector3(location.x, 1, location.z);
        transform.rotation = Quaternion.Euler(0,0,90);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        inventory.weaponIsFull = !inventory.weaponIsFull;
    }
}
