using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowOrbAfterShot : MonoBehaviour
{
    public KeyCode fireKey;
    public float startCoolDown;
    public GameObject GFX;
    private float _coolDown;

    void Start()
    {
        _coolDown = startCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        _coolDown -= Time.deltaTime;
        if (_coolDown <= 0)
        {
            GFX.gameObject.SetActive(true);
        }

        if ((Input.GetKey(fireKey)) && (_coolDown <= 0))
        {
            GFX.gameObject.SetActive(false);
            _coolDown = startCoolDown;
        }
    }
}
