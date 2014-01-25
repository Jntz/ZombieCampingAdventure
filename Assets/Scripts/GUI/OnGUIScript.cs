using UnityEngine;
using System.Collections;

public class OnGUIScript : MonoBehaviour {

	//Menubutton
	public Rect menuBtnRect = new Rect(0f, 	//x
	                                   0f,	//y
	                                   0f,	//width
	                                   0f);	//height
	//Healthbar
	public Rect fullHealthBarRect = new Rect(0f, 	//x
	                                     	0f,	//y
	                                     	0f,	//width
	                                     	0f);	//height
	private Rect healthBarRect;	//copy fullHealtBarRect

	public Rect itemRect = new Rect(0f, 	//x
	                                0f,	//y
	                                84f,	//width
	                                84f);	//height
	public int itemCount = 3; //Determinate how many item (what player hold) we want to show in GUI


	public float[] itemXPositions;

	public Texture2D redColorTexture;
	public Texture2D blueColorTexture;
	public Texture2D itemBorderTexture;
	public Texture2D itemBorderSelectedTexture;

	private int selectedItemIndex = 2;
	private Rect tempItemRect; 
	//Item area (image + borders)
	//

	// Use this for initialization
	void Start () {
		//Rect position initializations

		menuBtnRect.x = 5f;
		menuBtnRect.y = Screen.height - 5f - menuBtnRect.height;

		fullHealthBarRect.x = Screen.width/2f - fullHealthBarRect.width/2f;
		fullHealthBarRect.y = Screen.height - 5f - fullHealthBarRect.height;

		healthBarRect = fullHealthBarRect;

		itemRect.y = Screen.height - 5f - itemRect.height;

		itemXPositions = new float[itemCount];
		for(int i = 0; i < itemXPositions.Length; i++) {
			if(i == 0) {	//first is exception to logic
				itemXPositions[i] = Screen.width - 5f - itemRect.width;
			}
			else {
				itemXPositions[i] = itemXPositions[i - 1] - 10f - itemRect.width;
			}
		}


	}

	void Update () {
		//Only for testing purpose
		if (Input.GetKeyDown ("0")) {
			ChangeSelectedItemIndex(0);
		}
		else if(Input.GetKeyDown ("1")) {
			ChangeSelectedItemIndex(1);
		}
		else if(Input.GetKeyDown ("2")) {
			ChangeSelectedItemIndex(2);
		}

		else if(Input.GetKeyDown ("3")) {
			ChangeSelectedItemIndex(3);
		}
		else if(Input.GetKeyDown ("4")) {
			ChangeSelectedItemIndex(4);
		}
		else if(Input.GetKeyDown ("5")) {
			ChangeSelectedItemIndex(5);
		}
		else if(Input.GetKeyDown ("6")) {
			ChangeSelectedItemIndex(6);
		}
		else if(Input.GetKeyDown ("7")) {
			ChangeSelectedItemIndex(7);
		}
		else if(Input.GetKeyDown ("8")) {
			ChangeSelectedItemIndex(8);
		}
		else if(Input.GetKeyDown ("9")) {
			ChangeSelectedItemIndex(9);
		}
	}

	void OnGUI() {
		if(GUI.Button(menuBtnRect, "Menu")) {
			//Open menu
		}
		//draw blue bar (health and maxhealth difference)
		GUI.DrawTexture(healthBarRect, blueColorTexture);
		
		//Draw red bar (health)
		GUI.DrawTexture(healthBarRect, redColorTexture);

		//Draw itemBorderTextures
		tempItemRect = itemRect;

		for(int i = 0; i < itemXPositions.Length; i++) {
			tempItemRect.x = itemXPositions[i];	//change original rect our calculated x value

			//if i == selectedItemIndex => item is selected and border texture is different
			GUI.DrawTexture(tempItemRect, (i == selectedItemIndex) ? itemBorderSelectedTexture : itemBorderTexture); 
		}
	}

	//whichone number user pressed: would be 0 - 9
	public void ChangeSelectedItemIndex(int whichOne) {
		if(whichOne > itemCount) return;
		
		selectedItemIndex = itemCount - whichOne;
	}

}
