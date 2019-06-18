using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    CharacterStats stats;
    public float restartDelay = 5f;
    public GameObject player;

    Animator anim;
    float restartTimer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        stats = player.GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.CurrentHealth <= 0)
        {
            PlayerMovement playerMovement = player.GetComponent(typeof(PlayerMovement)) as PlayerMovement;
            PlayerRotation playerRotation = player.GetComponentInChildren(typeof(PlayerRotation)) as PlayerRotation;
            CameraController cameraController = player.GetComponent(typeof(CameraController)) as CameraController;

            playerMovement.enabled = false;
            playerRotation.enabled = false;
            cameraController.enabled = false;
            restartTimer += Time.deltaTime;


            if(restartTimer >= restartDelay)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
