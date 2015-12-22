using UnityEngine;
using System.Collections;

/**
 * Helps to deal with the dead objects or droppe ball
 * 
 * */
public class DeadZone : MonoBehaviour
{
	void OnTriggerEnter (Collider col)
	{
		GM.instance.LoseLife ();
	}
}
