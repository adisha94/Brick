using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour
{
	public GameObject brickParticle; // refers to the BrickParticle object in the scene view

	/*
	 * Will activate once ball makes impact with the bricks
	 **/
	void OnCollisionEnter(Collision other)
	{
		Instantiate (brickParticle, transform.position, Quaternion.identity);
		GM.instance.DestroyBrick();
		Destroy(gameObject);
	}
}