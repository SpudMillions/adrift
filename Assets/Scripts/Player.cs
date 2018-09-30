using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
	//config
	[FormerlySerializedAs("runSpeed")] [SerializeField] private float _runSpeed = 5f;
	
	//state
	private bool isAlive = true;
	
	//caches component references
	private Rigidbody2D _playerRigidBody;
	private Animator _playerAnimator;
	
	// Use this for initialization
	private void Start ()
	{
		_playerRigidBody = GetComponent<Rigidbody2D>();
		_playerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	private void Update ()
	{
		Run();
		FlipSprite();
	}

	//methods
	private void Run()
	{
		var controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //value is between -1 and +1
		var playerVelocity = new Vector2(controlThrow * _runSpeed, _playerRigidBody.velocity.y);
		_playerRigidBody.velocity = playerVelocity;
		
		//set animation to running if player is moving
		var playerHasHorizontalSpeed = Mathf.Abs(_playerRigidBody.velocity.x) > Mathf.Epsilon;
		_playerAnimator.SetBool("Running", playerHasHorizontalSpeed);
		
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
