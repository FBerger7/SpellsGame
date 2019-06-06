using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;

            if(restartTimer >= restartDelay)
            {
                SceneManager.UnloadSceneAsync("Swamp");
                SceneManager.LoadSceneAsync("Swamp");
                //player.GetComponentInChildren<SpellController>().SetCamera();
            }
        }
    }
}
