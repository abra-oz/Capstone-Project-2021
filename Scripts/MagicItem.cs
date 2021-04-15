using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script goes on the object you're going to pick up.
// You will need to set a tag for the object, currently using "Weapon" and "Magic"


public class MagicItem : MonoBehaviour
{
    // Creating a private inventory of type Inventory (based on the Inventory script we created).
    // - These classes are apparently automatically public.
    public Inventory inventory;
    // This is the graphics for the game object.
    // Created Unity-side.
    public GameObject itemButton;
    public float magicDamage;
    public float magicAttackCooldown;
    public float magicRange;
    public float magicManaUse;

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
            if (!inventory.magicIsFull)
            {
                if (gameObject.tag == "Magic")
                {
                    // Item can be added to the inventory
                    Instantiate(itemButton, inventory.magicSlot.transform, false);
                    inventory.magicIsFull = true;
                    Transform parent = other.transform.GetChild(2);
                    transform.SetParent(parent);
                    transform.position = parent.position;
                    transform.rotation = parent.rotation * new Quaternion(-0, -0, 0, 0);
                }
            }
        }
    }
}
