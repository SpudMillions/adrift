using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 1f;
	
	private Rigidbody2D _enemyRigidBody;
	
	void Start ()
	{
		_enemyRigidBody = GetComponent<Rigidbody2D>();
	}
	
	
	void Update ()
	{
		_enemyRigidBody.velocity = new Vector2(_moveSpeed, 0f);
	}
}
