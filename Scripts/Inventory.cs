using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Test for whether slot has an item in it already or not.
    public bool magicIsFull;
    public bool weaponIsFull;
    // Actually stores that item
    public GameObject weaponSlot;
    public GameObject magicSlot;

    public WeaponItem equippedWeapon;
    public MagicItem equippedMagic;
}
