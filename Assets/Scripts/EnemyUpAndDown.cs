using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemyUpAndDown : MonoBehaviour {

    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _unitsToWander = 2f;
    private float _startingPos;
    private Random _random = new Random();
	
    private Rigidbody2D _enemyRigidBody;

    private void Start ()
    {
        var rand = _random.Next();
        _enemyRigidBody = GetComponent<Rigidbody2D>();
        _startingPos = _enemyRigidBody.position.y;
        _enemyRigidBody.velocity = rand % 2 == 0 ? new Vector2(0f,-_moveSpeed) : new Vector2(0f,_moveSpeed);      
    }


    private void Update ()
    {
        WanderUpAndDown();
    }

    private void WanderUpAndDown()
    {
        if (_enemyRigidBody.position.y >= _startingPos + _unitsToWander) //max height
        {
            _enemyRigidBody.velocity = new Vector2(0f,-_moveSpeed);	
        }
        else if (_enemyRigidBody.position.y <= _startingPos - _unitsToWander) //lower limit
        {
            _enemyRigidBody.velocity = new Vector2(0f,_moveSpeed);	
        }
    }
}
