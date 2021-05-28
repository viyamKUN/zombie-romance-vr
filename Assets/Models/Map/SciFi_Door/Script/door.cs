using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	GameObject thedoor;
	private bool isDoorOpen = false;

	/*
	void OnTriggerEnter ( Collider obj  ){
		thedoor= GameObject.FindWithTag("SF_Door");
		if(obj.gameObject.CompareTag("Player"))
		{
			thedoor.GetComponent<Animation>().Play("open");
			//GameManager.GM.EnterDoor();
		}
		//thedoor.GetComponent<Animation>().Play("open");
	}
	*/

	void OnTriggerExit ( Collider obj  )
	{
		if(isDoorOpen)
		{
			thedoor= GameObject.FindWithTag("SF_Door");
			thedoor.GetComponent<Animation>().Play("close");
			GameManager.GM.EnterDoor();
		}
	}

	public void OpenDoor()
	{
		thedoor= GameObject.FindWithTag("SF_Door");
		thedoor.GetComponent<Animation>().Play("open");
		GameManager.GM.UseCardKey();
		isDoorOpen = true;
	}
	/*
	public void CloseDoor()
	{
		thedoor= GameObject.FindWithTag("SF_Door");
		thedoor.GetComponent<Animation>().Play("close");
	}
	*/
}