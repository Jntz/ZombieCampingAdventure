using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private GameObject game;
	private GameScript gameScript;
	private Transform kirves;
	private bool playerHit = false; 
	// Use this for initialization
	void Start () {
		game = GameObject.Find("GAME");
		gameScript = game.GetComponent<GameScript>();

		kirves = transform.FindChild("Kirves");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0) && !playerHit) {
			//HIT ANIMATION
		
		}
	}

	IEnumerator playerHitting() {
		Vector3 currentRotation = kirves.rotation.eulerAngles;
		Vector3 wantedRotation = new Vector3(kirves.rotation.x - 10f, kirves.rotation.y - 10f, kirves.rotation.z);
		
		kirves.eulerAngles = Vector3.Slerp(currentRotation, wantedRotation, 1f);
		yield return new WaitForSeconds(1f);


		playerHit = false;

	}

	public void getItem(string itemType) {
		Debug.Log("get item");
	}
}
