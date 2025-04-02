using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{
	private float startY;

	[Header("Set in Inspector")]
	public GameObject dragonEggPrefab;
	public float speed = 1f;
	public float timeBetweenEggDrops = 2f;
	public float leftRightDistance = 10f;
	public float changeDirectionChance = 0.1f;

	void Start()
	{
		startY = transform.position.y;
		Invoke(nameof(DropEgg), 2f);
	}

	void DropEgg()
	{
		UnityEngine.Debug.Assert(dragonEggPrefab != null, "dragonEggPrefab is not set for EnemyDragon!");

		GameObject egg = Instantiate(dragonEggPrefab);
		egg.transform.position = transform.position + Vector3.up * 5f;

		UnityEngine.Debug.Log("Drop Egg");

		Invoke(nameof(DropEgg), timeBetweenEggDrops);
	}

	void Update()
	{
		Move();
		CheckDirectionChange();
	}

	void Move()
	{
		float yOffset = Mathf.Sin(Time.time * speed) * 2f; // Shifting also by Y
		transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, startY + yOffset, transform.position.z);
	}


	void CheckDirectionChange()
	{
		if (transform.position.x < -leftRightDistance)
		{
			speed = Mathf.Abs(speed);
		}
		else if (transform.position.x > leftRightDistance)
		{
			speed = -Mathf.Abs(speed);
		}
		else if (UnityEngine.Random.value < changeDirectionChance * Time.deltaTime)
		{
			speed *= -1;
		}
	}
}
