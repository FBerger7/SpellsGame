using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public KeyCode runKey;
    public float runBoost;

    public KeyCode dashKey;
    public float dashSpeed;
    public float startDashTime;
    public float startDashColdown;

    private Rigidbody _playerBody;

    private Vector3 _direction;

    private float _dashTime;
    private float _dashColdown;
    private bool _isDashing = false;


    // Start is called before the first frame update
    void Start()
    {
        _playerBody = GetComponent<Rigidbody>();
        _dashTime = startDashTime;
        _dashColdown = 0;
    }

    void FixedUpdate()
    {
        //Gets direction in witch user wants to perform movement
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));


        //Checks for run key
        if(Input.GetKeyDown(runKey))
        {
            speed *= runBoost;
        }
        else if (Input.GetKeyUp(runKey))
        {
            speed /= runBoost;
        }


        if (_isDashing == true)
        {
            _dashTime -= Time.deltaTime;
            if (_dashTime <= 0)
            {
                _dashTime = startDashTime;
                _playerBody.velocity = Vector3.zero;
                _dashColdown = startDashColdown;
                _isDashing = false;
            }
        }
        else if (_isDashing == false)
        {
            if (Input.GetKeyDown(dashKey) && _dashColdown <=0)
            {
                _isDashing = true;
                _playerBody.velocity = _direction * dashSpeed;
            }
            else
            {
                _dashColdown -= Time.deltaTime;
                transform.Translate(_direction * speed * Time.deltaTime);
            }
        }
    }
}
