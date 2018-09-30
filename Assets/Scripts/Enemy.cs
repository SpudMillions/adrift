using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 1f;
	
	private Rigidbody2D _enemyRigidBody;

	private void Start ()
	{
		_enemyRigidBody = GetComponent<Rigidbody2D>();
	}


	private void Update ()
	{
		if (IsFacingRight())
		{
			_enemyRigidBody.velocity = new Vector2(_moveSpeed, 0f);	
		}
		else
		{
			_enemyRigidBody.velocity = new Vector2(-_moveSpeed, 0f);
		}
		
	}

	private bool IsFacingRight()
	{
		return transform.localScale.x > 0;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		transform.localScale = new Vector2(-(Mathf.Sign(_enemyRigidBody.velocity.x)), 1f);
	}
}
