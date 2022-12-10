using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AllDelete_voxel : MonoBehaviour
{
	//public enum CollectibleTypes { NoType, Type1, Type2, Type3, Type4, Type5 }; // you can replace this with your own labels for the types of collectibles in your game!

	//public CollectibleTypes CollectibleType; // this gameObject's type

	public bool rotate; // do you want it to rotate?

	public float rotationSpeed;

	public AudioClip collectSound;

	public GameObject collectEffect;

	public GameObject changeObject;
	public AudioClip explosionSound;

	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{

		if (rotate)
			transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Airplane")
		{
			Collect();
		}
	}

	public void Collect()
	{
		if (collectSound)
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
		if (collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);

		//Below is space to add in your code for what happens based on the collectible type
		/*
		if (CollectibleType == CollectibleTypes.NoType)
		{

			//Add in code here;

			Debug.Log("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type1)
		{

			//Add in code here;

			Debug.Log("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type2)
		{

			//Add in code here;

			Debug.Log("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type3)
		{

			//Add in code here;

			Debug.Log("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type4)
		{

			//Add in code here;

			Debug.Log("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type5)
		{

			//Add in code here;

			Debug.Log("Do NoType Command");
		}*/

		GameObject[] obj = GameObject.FindGameObjectsWithTag("Meteo");
		Debug.Log(obj.Length);
		
		for (int i=0; i<obj.Length; i++)
        {
			if (collectSound)
				AudioSource.PlayClipAtPoint(explosionSound, transform.position);

			Destroy(obj[i]);

			GameObject voxel = Instantiate(changeObject);
			voxel.transform.position = obj[i].gameObject.transform.position;
			Destroy(voxel, 1.0f);
		}
		
		Destroy(gameObject);
	}
}
