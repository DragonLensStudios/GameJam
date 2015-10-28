using UnityEngine;
//[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class PlayerObjectInteraction : MonoBehaviour
{
    public LayerMask interactionLayers;
	private GameObject interacted_object;
    private PlayerMovement playerMove;
    private Vector3 pos = Vector3.zero;

    public void Awake()
    {
        playerMove = GetComponent<PlayerMovement>();
    }

    public void Update()
    {
        Interaction();
    }

    public void Interaction()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (playerMove.facingDirection == Direction.UP)
            {
                pos = Vector3.up;
            }
            if (playerMove.facingDirection == Direction.DOWN)
            {
                pos = Vector3.down;
            }
            if (playerMove.facingDirection == Direction.RIGHT)
            {
                pos = Vector3.right;
            }
            if (playerMove.facingDirection == Direction.LEFT)
            {
                pos = Vector3.left;
            }

            Debug.DrawLine(transform.position, transform.position + pos , Color.cyan);
            var col = Physics2D.Linecast(transform.position, transform.position + pos, interactionLayers);

            if (col)
            {
                interacted_object = col.transform.gameObject;
            }
            else
            {
                interacted_object = null;
            }
        }

        if (interacted_object != null && interacted_object.GetComponent<ObjectAction>() != null)
        {
            var action = interacted_object.GetComponent<ObjectAction>();
            action.onInteract.Invoke();
            Debug.Log("OBJECT INTERACTED: " + interacted_object.name);
            interacted_object = null;
        }
    }

    //	void OnTriggerEnter2D(Collider2D col)
    //	{
    //		interacted_object = col.gameObject;
    //	}
    //
    //    void OnTriggerStay2D(Collider2D col)
    //    {
    //        if (Input.GetButtonDown("Submit"))
    //        {
    //            if (interacted_object != null && col.gameObject == interacted_object)
    //            {
    //                var action = interacted_object.GetComponent<ObjectAction>();
    //                if (action != null)
    //                {
    //                    action.onInteract.Invoke();
    //                }
    //            }
    //        }
    //
    //    }

    //    void OnTriggerExit2D(Collider2D col)
    //    {
    //        interacted_object = null;
    //    }



}
