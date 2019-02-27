using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 direction =new Vector3(0.0f,0.0f,0.0f);
    public float speed;
    public float runBoost;

    Rigidbody playerBody;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    public float DashTimeColdown;
    bool dashing = false;
    private int playerDirection= 0;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(dashing);
        Debug.Log(dashTime);
        if (dashing == true)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0)
            {
                dashTime = startDashTime;
                playerBody.velocity = Vector3.zero;
                dashing = false;
            }
        }
        else if (dashing == false)
        {
            PlayerInputDirection();

            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                Dash();
            }
            else
            {
                DoRun();
                Move();
            }
        }
        
        playerDirection = 0;
    }
    void PlayerInputDirection()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerDirection++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerDirection--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerDirection += 3;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerDirection -= 3;
        }
    }

    void Move()
    {
        switch (playerDirection)
        {
            //Dash forward
            case 1:
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                break;
            //Dash back
            case -1:
                transform.Translate(Vector3.back * speed * Time.deltaTime);
                break;
            //Dash right
            case 3:
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;
            //Dash left
            case -3:
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                break;
            //Dash forward-right
            case 4:
                transform.Translate(new Vector3(0.707f, 0, 0.707f) * speed * Time.deltaTime);
                break;
            //Dash forward-left
            case -2:
                transform.Translate(new Vector3(-0.707f, 0, 0.707f) * speed * Time.deltaTime);
                break;
            //Dash back-right
            case 2:
                transform.Translate(new Vector3(0.707f, 0, -0.707f) * speed * Time.deltaTime);
                break;
            //Dash back-left
            case -4:
                transform.Translate(new Vector3(-0.707f, 0, -0.707f) * speed * Time.deltaTime);
                break;
            default:
                break;
        }
    }

    void DoRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= runBoost;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= runBoost;
        }
    }

    void Dash()
    {
        dashing = true;
        switch(playerDirection)
        {
            //Dash up
            case 1:
                playerBody.velocity = Vector3.forward * dashSpeed;
                break;
            //Dash down
            case -1:
                playerBody.velocity = Vector3.back * dashSpeed;
                break;
            //Dash right
            case 3:
                playerBody.velocity = Vector3.right * dashSpeed;
                break;
            //Dash left
            case -3:
                playerBody.velocity = Vector3.left * dashSpeed;
                break;
            //Dash up-right
            case 4:
                playerBody.velocity = new Vector3(0.707f, 0, 0.707f) * dashSpeed;
                break;
            //Dash up-left
            case -2:
                playerBody.velocity = new Vector3(-0.707f, 0, 0.707f) * dashSpeed;
                break;
            //Dash down-right
            case 2:
                playerBody.velocity = new Vector3(0.707f, 0, -0.707f) * dashSpeed;
                break;
            //Dash down-left
            case -4:
                playerBody.velocity = new Vector3(-0.707f, 0, -0.707f) * dashSpeed;
                break;
            default:
                break;
        }
            
    }
}
