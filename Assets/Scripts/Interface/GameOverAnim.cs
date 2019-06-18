using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAnim : MonoBehaviour
{

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("GameOver");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
