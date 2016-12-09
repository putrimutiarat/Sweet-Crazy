using UnityEngine;
using System.Collections;

public class AwalMenu : MonoBehaviour {
    static AwalMenu my;
    public static AwalMenu Instance { get { return my; } }
	// Use this for initialization
	void Start () {
        my = this;
      
        if (PlayerPrefs.GetString("namsas") != "") {
            Application.LoadLevel("Menu");
        }
        Screen.SetResolution(720 , 1280,false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public int lewat;
    public string stringToEdit = "Name Just use 1 word";
    void OnGUI()
    {
        stringToEdit = GUI.TextField(new Rect(0 , 400, 1280, 200), stringToEdit,24);
    }
    string[] tes;
    public void SaveName()
    {
        if (stringToEdit != "Enter Your Name Here" && stringToEdit != "")
        {
            tes = stringToEdit.Split(' ');
            print(tes.Length);
            if (tes.Length < 2)
            {
                PlayerPrefs.SetString("namsas", stringToEdit);
                Application.LoadLevel("Menu");
            }
            else {
                stringToEdit = "Name Just use 1 word";
            }
        }

    }
}
