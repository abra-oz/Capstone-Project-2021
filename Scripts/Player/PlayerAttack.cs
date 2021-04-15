using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform attackPos;
    public PlayerController player;

    public GameObject[] weapons;
    float damage;
    float attackRange;
    float currentAttackCooldown;
    float attackCooldown;
    string weaponName;
    

    internal float currentHealth;
    float currentMana;
    float HealthBar;
    float x;

    Vector3 startPos;

    private Enemy enemy;

    void Awake()
    {
        startPos = this.transform.position;
    }
    void Start()
    {
        currentHealth = player.maxHealth;
        currentMana = player.maxMana;

        HealthBar = player.Health.localScale.x;
        x = HealthBar;

        weapons = GameObject.FindGameObjectsWithTag("Weapon");

        for (int i = 0; i < weapons.Length; i++)
        {
            Debug.Log(weapons[i].GetComponent<WeaponItem>().weaponName);
        }
    }
    
    public void Update()
    {
        if (player.inventory.weaponIsFull)
        {
            GetWeapon();
        }
    }


    public void GetWeapon()
    {
        // Create an array that holds 'Weapon' objects,
        // - Sort through this array to check if any of the weapons
        // - in it are currently a child of the player
        // - If so, update our stats by assigning our equipped weapon.
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].transform.IsChildOf(player.transform))
            {
                player.inventory.equippedWeapon = weapons[i].GetComponent<WeaponItem>();
                weaponName = player.inventory.equippedWeapon.name;
                damage = player.inventory.equippedWeapon.weaponDamage;
                attackRange = player.inventory.equippedWeapon.weaponRange;
                attackCooldown = player.inventory.equippedWeapon.weaponAttackCooldown;
            }
        }
    }

    public void AttackEnemies()
    {
        if (player.inventory.equippedWeapon != null)
        {
            //Debug.Log("You have the " + weaponName + " equipped!");
            //Debug.Log("The elapsed cooldown time is " + currentAttackCooldown + " out of " + attackCooldown);
            if (currentAttackCooldown >= attackCooldown * Time.deltaTime)
            {
                Debug.Log("My " + weaponName + " does " + damage + " damage!");
                Collider[] enemiesToDamage = Physics.OverlapSphere(attackPos.position, attackRange);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    if (enemiesToDamage[i].gameObject.CompareTag("Enemy"))
                    {
                        enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    }
                }
                currentAttackCooldown = 0;
            }
            else
            {
                currentAttackCooldown += Time.deltaTime;
            }
        }
    }

    public void DamagePlayer(float damageTaken)
    {
        currentHealth -= damageTaken;
        float missingHealth = currentHealth / player.maxHealth;

        if (x != HealthBar * missingHealth)
        {
            x = HealthBar * missingHealth;
        }

        if (currentHealth > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentHealth -= 2;
            }
        }
        Debug.Log(currentHealth + "/" + player.maxHealth);
        player.Health.localScale = new Vector3(x, .5f, 1);

        if (currentHealth <= 0)
        {
            Debug.Log("<color=red>You have died!</color>");
            this.transform.position = startPos;
            currentHealth = player.maxHealth;
        }

        //public void PlayerTakeDamage(float enemyDamage)
//{
       //     currentHealth -= enemyDamage;
        //    Debug.Log("Your Taking Damage!");
        //}
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    
}

