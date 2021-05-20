using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	GameObject thedoor;

	void OnTriggerEnter ( Collider obj  ){
		thedoor= GameObject.FindWithTag("SF_Door");
		if(obj.gameObject.CompareTag("Player"))
		{
			thedoor.GetComponent<Animation>().Play("open");
			//GameManager.GM.EnterDoor();
		}
		//thedoor.GetComponent<Animation>().Play("open");
	}

	void OnTriggerExit ( Collider obj  ){
		thedoor= GameObject.FindWithTag("SF_Door");
		thedoor.GetComponent<Animation>().Play("close");
		GameManager.GM.EnterDoor();
	}

	public void OpenDoor()
	{
		Debug.Log("open the door");
		thedoor= GameObject.FindWithTag("SF_Door");
		thedoor.GetComponent<Animation>().Play("open");
		GameManager.GM.UseCardKey();
		Debug.Log("open the door");
	}
	/*
	public void CloseDoor()
	{
		thedoor= GameObject.FindWithTag("SF_Door");
		thedoor.GetComponent<Animation>().Play("close");
	}
	*/
}