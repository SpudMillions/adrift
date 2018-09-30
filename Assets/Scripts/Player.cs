﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
	// Configs
	[SerializeField] private float _runSpeed = 5f;
	[SerializeField] private float _jumpSpeed = 5f;
	[SerializeField] private float _climbSpeed = 5f;
	
	// State
	private bool isAlive = true;
	
	// Cached component references
	private Rigidbody2D _playerRigidBody;
	private Animator _playerAnimator;
	private Collider2D _playerCollider;
	private float _gravityScaleAtStart;

	// Use this for initialization
	private void Start ()
	{
		_playerRigidBody = GetComponent<Rigidbody2D>();
		_playerAnimator = GetComponent<Animator>();
		_playerCollider = GetComponent<Collider2D>();
		_gravityScaleAtStart = _playerRigidBody.gravityScale;
	}
	
	// Update is called once per frame
	private void Update ()
	{
		Run();
		Jump();
		ClimbLadder();
		FlipSprite();	
	}

	// Methods
	private void Run()
	{
		var controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //value is between -1 and +1
		var playerVelocity = new Vector2(controlThrow * _runSpeed, _playerRigidBody.velocity.y);
		_playerRigidBody.velocity = playerVelocity;
		
		//set animation to running if player is moving
		var playerHasHorizontalSpeed = Mathf.Abs(_playerRigidBody.velocity.x) > Mathf.Epsilon;
		_playerAnimator.SetBool("Running", playerHasHorizontalSpeed);	
	}

	private void Jump()
	{
		//don't want to jump if we are already jumping
		if (!_playerCollider.IsTouchingLayers(LayerMask.GetMask("Foreground"))) { return; }
		
		if(CrossPlatformInputManager.GetButtonDown(("Jump")))
		{
			var jumpVelocityToAdd = new Vector2(0f, _jumpSpeed);
			_playerRigidBody.velocity += jumpVelocityToAdd;
		}
	}

	private void ClimbLadder()
	{
		//don't want to climb if we are already climbing something
		if (!_playerCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
		{
			_playerAnimator.SetBool("Climbing",false);
			_playerRigidBody.gravityScale = _gravityScaleAtStart;
			return;
		}

		var controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
		var climbVelocity = new Vector2(_playerRigidBody.velocity.x, controlThrow * _climbSpeed);
		_playerRigidBody.velocity = climbVelocity;
		_playerRigidBody.gravityScale = 0f;

		var playerHasVerticalSpeed = Mathf.Abs(_playerRigidBody.velocity.y) > Mathf.Epsilon;
		_playerAnimator.SetBool("Climbing", playerHasVerticalSpeed);
	}
	
	private void FlipSprite()
	{
		var playerHasHorizontalSpeed = Mathf.Abs(_playerRigidBody.velocity.x) > Mathf.Epsilon;
		if (playerHasHorizontalSpeed)
		{
			transform.localScale = new Vector2(Mathf.Sign(_playerRigidBody.velocity.x), 1f);
		}
	}
}
