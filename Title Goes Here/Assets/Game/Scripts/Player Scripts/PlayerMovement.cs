using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float playerX;
    public float playerY;
    public Animator anim;


    public void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

	// Use this for initialization
	public void Start() 
	{
	
	}
	
	// Update is called once per frame
	public void Update() 
	{
	    Movement();
	}

    public void Movement()
    {
        playerX = Input.GetAxisRaw("Horizontal");
        playerY = Input.GetAxisRaw("Vertical");

        if (playerX != 0 || playerY != 0)
        {
            anim.SetFloat("PlayerX", playerX);
            anim.SetFloat("PlayerY", playerY);
            anim.SetBool("IsWalking",true);
            transform.position += new Vector3(playerX, playerY) * Time.deltaTime * Speed;
        }
        else
        {
            anim.SetBool("IsWalking",false);
        }

    }
}
