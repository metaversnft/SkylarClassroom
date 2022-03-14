using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public float blink;
    public float immuned;
    public float Player;

    public Renderer modelRender1;
    public Renderer modelRender2;
    private float blinkTime = 0.1f;
    private float immunedTime;

    public Transform respawnTarget;
    private bool respawning;
    private Vector3 respawnLocation;


    void Start()
    {

        currentHealth = maxHealth;

        respawnLocation = respawnTarget.transform.position;

    }

    void Update()
    {
        if (immunedTime > 0)
        {

            immunedTime -= Time.deltaTime;

            blinkTime -= Time.deltaTime;

            if (blinkTime <= 0)
            {
                modelRender1.enabled = !modelRender1.enabled;
                modelRender2.enabled = !modelRender2.enabled;

                blinkTime = blink;
            }
            if (immunedTime <= 0)
            {
                modelRender1.enabled = true;
                modelRender2.enabled = true;
            }
        }
    }


    public void DamagePlayer(int Hurt, Vector3 direction)
    {
        if (immunedTime <= 0)
        {

            currentHealth -= Hurt;

            if (currentHealth <= 0)
            {
                Respawn();
            }
            else
            {

                immunedTime = immuned;
                modelRender1.enabled = false;
                modelRender2.enabled = false;

                blinkTime = blink;
            }
        }
    }

    public void Respawn()
    {

        FindObjectOfType<GameManager>().EndGame();

    }

    public void CheckPoint(Vector3 newLocation)
    {

        respawnLocation = newLocation;

    }

    public void CurrentSpawnPoint(Vector3 newSpawn)
    {

        respawnLocation = newSpawn;

    }

    public void SelectedContinue()
    {

        respawnTarget.transform.position = respawnLocation;
        currentHealth = maxHealth;

    }
}


