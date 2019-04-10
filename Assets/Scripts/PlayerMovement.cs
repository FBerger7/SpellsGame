using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float startSpeed;
    public KeyCode runKey;
    public float runBoost;

    public KeyCode dashKey;
    public float dashSpeed;
    public float startDashTime;
    public float startDashCooldown;

    public KeyCode jumpKey;
    public float jumpForce;
    
    private Rigidbody _playerBody;

    private Vector3 _direction;

    private float _speed;

    private float _dashTime;
    private float _dashColdown;
    private bool _isDashing = false;


    // Start is called before the first frame update
    void Start()
    {
        _playerBody = GetComponent<Rigidbody>();
        _dashTime = startDashTime;
        _dashColdown = 0;
        _speed = startSpeed;
    }

    void FixedUpdate()
    {
        //Gets direction in witch user wants to perform movement
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        HandleRunning();

        ChceckJumping();

        HandleDashing();

        if (_isDashing == false)
        {
            PerformMovement();
        }
        else if (_isDashing == true)
        {
            ContinueDashing();
        }    
    }

    private void ChceckJumping()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            _playerBody.velocity = Vector3.up * jumpForce;
        }
    }

    //Performs player movement
    private void PerformMovement()
    {
        _dashColdown -= Time.deltaTime;
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    //Checks if player is trying to run, and sets propper speed
    private void HandleRunning()
    {
        if (Input.GetKey(runKey))
        {
            _speed = runBoost * startSpeed;
        }
        else
        {
            _speed = startSpeed;
        }
    }

    //Checks if player is trying to dash and if he can dash at given moment, if yes starts the dash
    private void HandleDashing()
    {
        if ((Input.GetKeyDown(dashKey)) && (_dashColdown <= 0) && (_isDashing==false))
        {
            _isDashing = true;
            _playerBody.velocity = _direction * dashSpeed;
        }
    }

    //Continues performing the dash and checks if it should end, if yes ends it 
    private void ContinueDashing()
    {
        _dashTime -= Time.deltaTime;
        if (_dashTime <= 0)
        {
            EndDash();
        }
    }

    //Ends, and resets the dash
    private void EndDash()
    {
        _dashTime = startDashTime;
        _playerBody.velocity =  Vector3.zero;

        _dashColdown = startDashCooldown;
        _isDashing = false;
    }
}
