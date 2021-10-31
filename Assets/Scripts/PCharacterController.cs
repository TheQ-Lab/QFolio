using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCharacterController : MonoBehaviour
{
    public float WalkAccellerator = 0.1f;
    public float WalkDecellerator = 0.25f;
    public float WalkCap = 2.0f;
    public float Gravity = 0.25f;
    public float VCap = 5f;

    private Rigidbody2D rBody;
    private int direction;
    private bool jump;
    private bool interact;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (ManagerGame.Instance.state != ManagerGame.State.Play)
            return;
        MovementController();
        
    }

    private void FixedUpdate()
    {
        if (ManagerGame.Instance.state != ManagerGame.State.Play)
            return;
        MovementExecutor();
    }

    private void MovementController()
    {
        direction = GetMovementDir();
        jump = GetJump();
        interact = GetInteract();

    }

    private void MovementExecutor()
    {
        if (direction > 0) {
            float newX = rBody.velocity.x + WalkAccellerator;
            newX = Mathf.Min(newX, WalkCap);
            rBody.velocity = new Vector2(newX, rBody.velocity.y);
        } else if (direction < 0)
        {
            float newX = rBody.velocity.x - WalkAccellerator;
            newX = Mathf.Max(newX, -WalkCap);
            rBody.velocity = new Vector2(newX, rBody.velocity.y);
        }
        else
        {
            float x = rBody.velocity.x;
            if (x > 0)
            {
                x -= WalkDecellerator;
                rBody.velocity = new Vector2(Mathf.Max(x, 0f), rBody.velocity.y);
            }
            else if (x < 0)
            {
                x += WalkDecellerator;
                rBody.velocity = new Vector2(Mathf.Min(x, 0f), rBody.velocity.y);
            }
        }

        Vector2 vel = rBody.velocity;
        if (!jump)
        {
            //vel.y -= Gravity;
            //vel.y = Mathf.Max(vel.y, -VCap);
            //rBody.AddForce(new Vector2(0f, -Gravity));
        } else
        {
            // if jump
        }
        //rBody.velocity = vel;
    }

    private int GetMovementDir()
    {
        // Not viable, because emulates Analog Stick, hereby sluggish
        float dir = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.RightArrow))
            dir = 1f;
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = -1f;
        return (int)dir;
    }

    private bool GetJump()
    {
        return Input.GetKey("y");
    }

    private bool GetInteract()
    {
        return Input.GetKey("x");
    }
}
