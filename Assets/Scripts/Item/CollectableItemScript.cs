using UnityEngine;
using System.Collections;

public class CollectableItemScript : MonoBehaviour {

	private GameObject game;
	private GameScript gameScript;
	private Transform itemTransform;
	private PlayerScript playerScript;
	
	// Use this for initialization
	void Start () {
		game = GameObject.Find("GAME");
		gameScript = game.GetComponent<GameScript>();
		playerScript = gameScript.Player.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && 
		   Mathf.Abs(Vector3.Distance(gameScript.Player.position, transform.position)) <= 2f) {
			playerScript.getItem(this.gameObject.name);
			Destroy(this.gameObject);
		}
	}
}
