using UnityEngine;
[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class PlayerObjectInteraction : MonoBehaviour {

	public GameObject interacted_objected;

	void OnTriggerEnter2D(Collider2D col)
	{
		interacted_objected = col.gameObject;
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (Input.GetButtonDown ("Submit")) 
		{
			if (interacted_objected != null && col.gameObject == interacted_objected) 
			{
				ObjectAction action = interacted_objected.GetComponent<ObjectAction>();
				if(action != null)
				{
					action.onInteract.Invoke();
				}
			}
		}

	}


}
