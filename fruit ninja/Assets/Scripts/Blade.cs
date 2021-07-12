using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
	private Rigidbody2D rb;

	public float min = 0.001f;
	Rigidbody2D rb1;
	Vector3 lmp;
	Vector3 mvl;
	Collider2D c;
	// Use this for initialization
	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		c = GetComponent<Collider2D>();
	}

	// Update is called once per frame
	void Update()
	{
		c.enabled = ismousemoving();
		SetBladeToMouse();
	}

	private void SetBladeToMouse()
	{
		var mousePos = Input.mousePosition;
		mousePos.z = 10; // distance of 10 units from the camera

		rb.position = Camera.main.ScreenToWorldPoint(mousePos);

	}

	private bool ismousemoving()
	{
		Vector3 cm = transform.position;
		float t = (lmp - cm).magnitude;
		lmp = cm;
		if(t>min)
		{
			return true;

		}
		else
		{
			return false;
		}
	}

}
