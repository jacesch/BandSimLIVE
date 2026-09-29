using UnityEngine;
using UnityEngine.XR;

public class HandDrumCollider : MonoBehaviour
{
 	public bool isFist = true;
	public Vector3 velocity { get; private set; }
	private Vector3 lastPosition;

	void Start()
	{
		lastPosition = transform.position;
	}

	void Update()
	{
		velocity = (transform.position - lastPosition) / Time.deltaTime;
		lastPosition = transform.position;
	}   
}
