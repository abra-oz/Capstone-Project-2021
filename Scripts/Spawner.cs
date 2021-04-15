using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject monster;
    bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            Instantiate(monster, transform.position + Vector3.ClampMagnitude(new Vector3(Random.Range(2, 5), 0, Random.Range(2, 5)), 5), transform.rotation, null);
            canSpawn = false;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        canSpawn = true;
    }
}
