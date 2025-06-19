using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
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
        tempHealth = playerHealth.vida;
        initialPlayerHealth = playerHealth.vida;

        textHealth.text = playerHealth.vida.ToString();
        textLives.text = playerLives.ToString();

        //anim = player.GetComponent<Animator>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( tempHealth != playerHealth.vida)
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
        textHealth.text = playerHealth.vida.ToString();
        tempHealth = playerHealth.vida;
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
