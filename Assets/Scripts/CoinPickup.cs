using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
	[SerializeField] private AudioClip coinPickUpSFX;
	[SerializeField] private int pointsForCoin = 10;
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
		FindObjectOfType<GameSession>().AddToScore(pointsForCoin);
		Destroy(gameObject);
	}
}
