using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField]
    int actualHealth;
    int currentHealth;
    void Start()
    {
        SetHealth();    
    }	
    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void SetHealth()
    {
        currentHealth = actualHealth;
    }
    public void SetInvincible()
    {
        currentHealth = 1000;
    }
    void Death()
    {
        GamePlayManager GPM = GameObject.Find("Canvas").GetComponent<GamePlayManager>();
        if (gameObject.CompareTag("Player"))
        {
            GPM.SpawnPlayer();
        }else{
            if (gameObject.CompareTag("Hunter")) MasterTracker.hunterTankDestroyed++;
            else if (gameObject.CompareTag("Destroyer")) MasterTracker.destroyerTankDestroyed++;
            else if (gameObject.CompareTag("Assault")) MasterTracker.assaultTankDestroyed++;
            else if (gameObject.CompareTag("Assistent")) MasterTracker.assistentTankDestroyed++;
        }
        Destroy(gameObject);
    }
}