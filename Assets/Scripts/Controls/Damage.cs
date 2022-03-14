using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int hurt = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Vector3 damageDirection = other.transform.position - transform.position;
            damageDirection = damageDirection.normalized;
            FindObjectOfType<PlayerHealth>().DamagePlayer(hurt, damageDirection);
        }

    }
}
