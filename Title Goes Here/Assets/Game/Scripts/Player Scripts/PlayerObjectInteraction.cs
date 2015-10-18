using UnityEngine;
[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class PlayerObjectInteraction : MonoBehaviour
{

	public GameObject interacted_object;

	void OnTriggerEnter2D(Collider2D col)
	{
		interacted_object = col.gameObject;
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (Input.GetButtonDown ("Submit")) 
		{
			if (interacted_object != null && col.gameObject == interacted_object) 
			{
				var action = interacted_object.GetComponent<ObjectAction>();
				if(action != null)
				{
					action.onInteract.Invoke();
				}
			}
		}

	}


}
