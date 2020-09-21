using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float acceleration = 0.5f;
    public Vector3 movementInput;

    private bool canDash = false;
    public float DashInput = 0f;
    public float DashDuration = 2f;
    private float _currentDashDuration = 0f;

    public float DashCoolDown = 3f;
    private float _currentDashCoolDown = 0;

    private Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        
    }
    
    private void FixedUpdate()
    {
        _currentDashCoolDown -= Time.deltaTime; 
        if (movementInput.sqrMagnitude > 0.01f)
        {
            movementInput.Normalize();
        }

        if (DashInput != 0f && _currentDashCoolDown <= 0f)
        {
            canDash = true;
        }

        if (canDash)
        {
            IncreaseSpeed();
        }        
        
        body.velocity = Vector3.MoveTowards(body.velocity, movementInput * moveSpeed, acceleration * Time.fixedDeltaTime);
    }

    public void IncreaseSpeed()
    {
        movementInput.x *= 5f;
        _currentDashDuration -= Time.deltaTime;
        if (_currentDashDuration <= 0f)
        {
            movementInput.x *= moveSpeed;
            canDash = false;
            _currentDashCoolDown = DashCoolDown;
            _currentDashDuration = DashDuration;
        }
    }
}