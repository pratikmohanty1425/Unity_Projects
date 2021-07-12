using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class playermovement : MonoBehaviour
{

	[Header("score")]
	public Slider slider;
	public GameObject lastline;
	public GameObject startline;

	[Header("PANEL")]
	public GameObject intropanle;

	//[Header("particle system")]
	//public GameObject g;


	[Header("walls")]
	[SerializeField] float walldistance =3f;
	[SerializeField] float mincamdistance = 4f;


	[Header("player movements")]
	[SerializeField] private float thrust = 100f;
	public Rigidbody rb;
	private Vector2 lastmpos;

	private void Start()
	{
		//g.SetActive(false);
		intropanle.SetActive(true);
	}
	void Update()
	{
		Vector2 deltapos = Vector2.zero;
		if(Input.GetMouseButton(0))
		{
			Vector2 crtmpos = Input.mousePosition;
			if(lastmpos==Vector2.zero)
			{
				lastmpos = crtmpos;
			}
			deltapos = crtmpos - lastmpos;
			lastmpos = crtmpos;
			Vector3 force = new Vector3(deltapos.x,0f,deltapos.y)*thrust;
			rb.AddForce(force);
		}
		else
		{
			lastmpos = Vector2.zero;
		}
		showscore();
	}
	private void FixedUpdate()
	{
		if (GameManager.singleton.gameended)
		{
			return;
		}
		if(GameManager.singleton.gamestarted)
		{
			rb.MovePosition(transform.position + Vector3.forward * 5f * Time.fixedDeltaTime);
		}
	}
	



	private void LateUpdate()
	{
		Vector3 pos = transform.position;
		if(transform.position.x <  -walldistance)
		{
			pos.x = -walldistance;
		}
		else if(transform.position.x >walldistance)
		{
			pos.x = walldistance;
		}
		if(transform.position.z<Camera.main.transform.position.z + mincamdistance)
		{
			pos.z = Camera.main.transform.position.z + mincamdistance;
		}
		transform.position = pos;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(GameManager.singleton.gameended)
		{
			return;
		}
		if(collision.gameObject.tag=="death")
		{
			//g.transform.position = gameObject.transform.position;
			//g.SetActive(true);
			Destroy(gameObject);
			GameManager.singleton.gameend(false);
			//panle1.SetActive(true);
			//SceneManager.LoadScene(0);
		}
	}

	void showscore()
	{
		if(gameObject.transform.position.z>=startline.transform.position.z 
			&& 
			gameObject.transform.position.z<= lastline.transform.position.z)
		{
			slider.maxValue = lastline.transform.position.z;
			slider.value = gameObject.transform.position.z;
		}
	}
}
