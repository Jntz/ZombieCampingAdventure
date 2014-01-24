using UnityEngine;
using System.Collections;

public class OnGUIScript : MonoBehaviour {

	//Menubutton
	public Rect menuBtnRect = new Rect(0f, 	//x
	                                   0f,	//y
	                                   0f,	//width
	                                   0f);	//height
	//Healthbar
	public Rect healthBarRect = new Rect(0f, 	//x
	                                     0f,	//y
	                                     0f,	//width
	                                     0f);	//height

	Texture2D redColorTexture = new Texture2D(128, 128);
	Texture2D blueColorTexture = new Texture2D(128, 128);

	//Item area (image + borders)
	//
	



	// Use this for initialization
	void Start () {
		//Rect position initializations
		menuBtnRect.x = 5f;
		menuBtnRect.y = Screen.height - 5f - menuBtnRect.height;

		renderer.material.mainTexture = redColorTexture;

		int y = 0;
		while (y < redColorTexture.height) {
			int x = 0;
			while (x < redColorTexture.width) {

				redColorTexture.SetPixel(x, y, Color.red);
				++x;
			}
			++y;
		}
		redColorTexture.Apply();

		/*for(int y = 0; y < redColorTexture.height; y++) {
			for(int x = 0; x < redColorTexture.width; x++) {
				redColorTexture.SetPixel(x,y, Color.red);
				//blueColorTexture.SetPixel(x,y, Color.blue);
			}
		}*/
		//redColorTexture.Apply();
		//blueColorTexture.Apply();
	}

	void OnGUI() {
		if(GUI.Button(menuBtnRect, "Menu")) {

		}
		//blue

		
		//red
		
	}
}
