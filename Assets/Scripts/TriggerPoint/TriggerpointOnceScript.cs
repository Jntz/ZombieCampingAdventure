using UnityEngine;
using System.Collections;

public class TriggerpointOnceScript : MonoBehaviour {
	//Trigger fired ONCE when user  
	private GameObject game;
	private GameScript gameScript;
	private bool playerTriggered = false;
	public GameObject spawnItem;
	public float spawnCount;	//how many we want spawn (count). -1 or smaller mean unlimited
	public float spawnDelaySeconds = 1f; //minimal is 1seconds
	public Transform spawnPoint;
	private float xIndex = 0f; //only for testing purpose

	// Use this for initialization
	void Start () {
		game = GameObject.Find("GAME");
		gameScript = game.GetComponent<GameScript>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		if(!playerTriggered) {
			if(other.name == gameScript.Player.name) {	//Player walk to trigger
				//START SPAWNING
				playerTriggered = true;	
				if(spawnPoint == null || spawnDelaySeconds < 1f | spawnItem == null) {
					Debug.LogError("spawnpoint is null OR spawdelay is smaller than 1 OR spawnItem is null");
					return;
				}

				StartCoroutine("spawningItem");
			}
		}
	}

	private IEnumerator spawningItem() {
		Vector3 newPos = spawnPoint.position;
		newPos.x += xIndex++;
		Instantiate(spawnItem, newPos, Quaternion.LookRotation(gameScript.Player.forward));
		Debug.Log("Instantiate " + spawnItem.name +"! " + "and spawnCount == " +spawnCount);
		yield return new WaitForSeconds(spawnDelaySeconds);
		if(spawnCount == -1) {
			Debug.Log("StartCoroutine(\"spawningItem\")");
			StartCoroutine("spawningItem");
		}
		else {
			spawnCount--;
			if(spawnCount > 0) {
				StartCoroutine("spawningItem");
			}
		}
	}

}
