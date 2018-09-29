using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
	[FormerlySerializedAs("runSpeed")] [SerializeField] private float _runSpeed = 5f;
	private Rigidbody2D _playerRigidBody;
	// Use this for initialization
	void Start ()
	{
		_playerRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	private void Update ()
	{
		Run();
		FlipSprite();
	}

	private void Run()
	{
		var controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //value is between -1 and +1
		var playerVelocity = new Vector2(controlThrow * _runSpeed, _playerRigidBody.velocity.y);
		_playerRigidBody.velocity = playerVelocity;
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
