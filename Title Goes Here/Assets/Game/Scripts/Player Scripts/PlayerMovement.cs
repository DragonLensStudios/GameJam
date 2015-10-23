using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    private int playerX;
    private int playerY;
    private Animator anim;
    public Direction facingDirection;

    public void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	public void Update() 
	{
	    Movement();
	}

    public void Movement()
    {
        playerX = (int)Input.GetAxisRaw("Horizontal");
        playerY = (int)Input.GetAxisRaw("Vertical");

        if (playerX == 0 && playerY == 0)
        {
            anim.SetBool("IsWalking",false);
        }
        else
        {
            anim.SetBool("IsWalking", true);
        }

        if (playerY > 0 && playerX == 0)
        {
            facingDirection = Direction.UP;
        }

        if (playerY < 0 && playerX == 0)
        {
            facingDirection = Direction.DOWN;
        }

        if (playerX > 0 && playerY == 0)
        {
            facingDirection = Direction.RIGHT;
        }

        if (playerX < 0 && playerY == 0)
        {
            facingDirection = Direction.LEFT;
        }

        if (anim.GetBool("IsWalking") == true)
        {
            switch (facingDirection)
            {

                case Direction.UP:
                    anim.SetFloat("PlayerX", 0);
                    anim.SetFloat("PlayerY", playerY);
                    transform.position += Vector3.up * Time.deltaTime * Speed;
                    break;
                case Direction.RIGHT:
                    anim.SetFloat("PlayerX", playerX);
                    anim.SetFloat("PlayerY", 0);
                    transform.position += Vector3.right * Time.deltaTime * Speed;
                    break;
                case Direction.DOWN:
                    anim.SetFloat("PlayerX", 0);
                    anim.SetFloat("PlayerY", playerY);
                    transform.position += Vector3.down * Time.deltaTime * Speed;
                    break;
                case Direction.LEFT:
                    anim.SetFloat("PlayerX", playerX);
                    anim.SetFloat("PlayerY", 0);
                    transform.position += Vector3.left * Time.deltaTime * Speed;
                    break;
            }
        }

    }
}
