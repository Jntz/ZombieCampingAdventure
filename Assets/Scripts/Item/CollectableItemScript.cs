using UnityEngine;
using System.Collections;

public class CollectableItemScript : MonoBehaviour {

	private GameObject game;
	private GameScript gameScript;
	private Transform itemTransform;

	// Use this for initialization
	void Start () {
		game = GameObject.Find("GAME");
		gameScript = game.GetComponent<GameScript>();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Distance between item and Player" + gameScript.Player.position);
		if(game != null && gameScript != null)
			Debug.Log ("Distance between item and Player" + Mathf.Abs(Vector3.Distance(gameScript.Player.position, transform.position)));


	}
}
