using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD_controller : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textLives;
    [SerializeField] TextMeshProUGUI textHealth;
    //[SerializeField] TextMeshProUGUI textEnemies;
    [SerializeField] GameObject player;
    //[SerializeField] Transform playerRespawnPosition;
    [SerializeField] int playerLives = 3;
    /*[SerializeField] int enemiesCount;
    [SerializeField] float timeToRespawn = 3f;*/

    Player playerHealth;
    //Animator anim;
    int tempHealth;
    int initialPlayerHealth;

    //float respawTimer;


    void Awake()
    {
        //textEnemies.text = enemiesCount.ToString();

        playerHealth = player.GetComponent<Player>();
        tempHealth = playerHealth.currentHealth;
        initialPlayerHealth = playerHealth.vida;

        textHealth.text = playerHealth.currentHealth.ToString();
        textLives.text = playerLives.ToString();

        //anim = player.GetComponent<Animator>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( tempHealth != playerHealth.currentHealth)
        {
            UpdateHealthUI();
        }        

        /*if(!playerHealth.IsAlive)
        {
            respawTimer += Time.deltaTime;

            if (respawTimer >= timeToRespawn)
            {
                RespawnPlayer();
                UpdateLivesUI();
            }
            
        }*/
    }

    /*void RespawnPlayer()
    {
        respawTimer = 0f;
        
        playerLives--;
        if(playerLives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        player.transform.position = playerRespawnPosition.position;
        playerHealth.Health = initialPlayerHealth;
        playerHealth.IsAlive = true;
        
        anim.Play("Idle");
    }*/

    void UpdateHealthUI()
    {
        textHealth.text = playerHealth.currentHealth.ToString();
        tempHealth = playerHealth.currentHealth;
    }

    void UpdateLivesUI()
    {
        textLives.text = playerLives.ToString();
    }

    /*public void EnemiesCount()
    {
        if ( enemiesCount > 0)
        {
            enemiesCount--;
            textEnemies.text = enemiesCount.ToString();
        }
        else
        {
            SceneManager.LoadScene("Victory");
        }
    }*/
}
