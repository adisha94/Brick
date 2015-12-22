using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour
{
	public GameObject brickParticle; // refers to the BrickParticle object in the scene view

	void OnCollisionEnter(Collision other)
	{
		Instantiate (brickParticle, transform.position, Quaternion.identity);
		GM.instance.DestroyBrick();
		Destroy(gameObject);
	}
}