using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
	public Rigidbody rb;
	private void FixedUpdate()
	{
		if (GameManager.singleton.gameended)
		{
			return;
		}
		else
		{
			rb.MovePosition(transform.position + Vector3.forward * 2 * Time.fixedDeltaTime);
		}
	}
}
