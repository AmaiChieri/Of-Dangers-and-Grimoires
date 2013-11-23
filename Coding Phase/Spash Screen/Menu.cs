using UnityEngine;
using System.Collections;
 
public class Menu : MonoBehaviour {
    public GUISkin guiSkin;
    public Texture2D background, LOGO;
    public bool DragWindow = false;
    public string[] AboutTextLines = new string[0];
 	public bool isMuted;
	
    private string clicked = "", MessageDisplayOnAbout = "About \n ";
    private Rect WindowRect = new Rect((Screen.width / 2) - 100, Screen.height / 2 -90, 250, 300);
    private float volume = 1.0f;
	
    private void Start() {		
        for (int x = 0; x < AboutTextLines.Length;x++ ) {
            MessageDisplayOnAbout += AboutTextLines[x] + " \n ";
        }
        MessageDisplayOnAbout += "Press Esc To Go Back";
    }

    private void OnGUI() {
		
        if (background != null) {
            GUI.DrawTexture(new Rect(0,0,Screen.width , Screen.height),background);
		}
        if (LOGO != null && clicked != "about") {
            GUI.DrawTexture(new Rect((Screen.width / 2) - 307, 30, 600, 200), LOGO);
		}
 
        GUI.skin = guiSkin;
        if (clicked == "") {
            WindowRect = GUI.Window(0, WindowRect, menuFunc, "Main Menu");
        }
        else if (clicked == "options") {
            WindowRect = GUI.Window(1, WindowRect, optionsFunc, "Options");
        }
        else if (clicked == "about") {
            GUI.Box(new Rect (0,0,Screen.width,Screen.height), MessageDisplayOnAbout);
        }
		else if (clicked == "resolution") {
            GUILayout.BeginVertical();
            for (int x = 0; x < Screen.resolutions.Length;x++ ) {
                if (GUILayout.Button(Screen.resolutions[x].width + "X" + Screen.resolutions[x].height)) {
                    Screen.SetResolution(Screen.resolutions[x].width,Screen.resolutions[x].height,true);
                }
            }
            GUILayout.EndVertical();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Back")) {
                clicked = "options";
            }
            GUILayout.EndHorizontal();
        }
    }
 

	
    private void optionsFunc(int id) {
		
		GUILayout.Space(60f);
		
        if (GUILayout.Button("Resolution")) {
            clicked = "resolution";
        }
		
		if (isMuted==true) {
			audio.volume = 0.0f;
		}
		if(isMuted==false) {
			audio.volume = 1.0f;
		}
		
        GUILayout.Box("Volume");
		
		isMuted = GUI.Toggle(new Rect(160,153,15,15),isMuted,"");
		
        volume = GUILayout.HorizontalSlider(volume ,0.0f,1.0f);
        AudioListener.volume = volume;
        if (GUILayout.Button("Back")) {
            clicked = "";
        }
		if (DragWindow) {
            GUI.DragWindow(new Rect (0,0,Screen.width,Screen.height));
		}
    }
 
    private void menuFunc(int id) {
		
		GUILayout.Space(60f);
		
        //buttons 
        if (GUILayout.Button("Play Game")) {
            //play game is clicked
			Application.LoadLevel("storyMode1_1");
		}
        if (GUILayout.Button("Options")) {
            clicked = "options";
        }
        if (GUILayout.Button("About")) {
            clicked = "about";
        }
        if (GUILayout.Button("Quit Game")) {
            Application.Quit();
        }
        if (DragWindow) {
            GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
		}
    }
 
    private void Update() {
        if (clicked == "about" && Input.GetKey (KeyCode.Escape)) {
            clicked = "";
		}
    }
}