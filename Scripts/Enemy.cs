using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("This is the enemy's health.")]
    public float enemyMaxHealth;
    [Tooltip("This is the enemy's speed.")]
    public float enemySpeed; 
    [Tooltip("This is the enemy's damage.")]
    public int enemyDamage;
    [Tooltip("Does this enemy drop an item?")]
    public bool dropItem;
    //private Animator anim; 
    //public GameObject bloodEffect;
    public PlayerController player;

    public GameObject droppedItem;

    public Vector3 enemyStartPostion;

    float enemyHealth;
    
    
    void Awake () 
    {
        enemyStartPostion = this.transform.position;
    }   
    void Start() 
    {
        //anim = GetComponent<Animator>(); 
        //anim.SetBool("ISRUNNING", true); 

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        enemyHealth = enemyMaxHealth;
    }
    void Update()
    {
        if ((transform.position - player.transform.position).magnitude < 20)
        {
            Vector3 moveTowards = player.transform.position - transform.position;
            transform.Translate(moveTowards.normalized * enemySpeed * Time.deltaTime);

            if (enemyHealth < enemyMaxHealth - (enemyMaxHealth / .5f))
            {
                transform.Translate(-moveTowards.normalized * enemySpeed * Time.deltaTime);
            }
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player")) 
        {
            player.playerAttack.DamagePlayer(enemyDamage * 5);  //think this should stay like this for enemy damage
        }
    }

    public void TakeDamage(float damage) 
    {
        enemyHealth -= damage; 

        if (enemyHealth <= 0)
        {
            Debug.Log(name + " died!");
            if (dropItem)
            {
                Instantiate(droppedItem, transform.position, transform.rotation, null);
            }
            Destroy(gameObject);
            transform.position = enemyStartPostion;
        }
    }
}


