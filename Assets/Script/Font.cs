using UnityEngine;
using System.Collections;

public class Font : MonoBehaviour {
    public string myTextOri;
    // Use this for initialization
    void Awake()
    {
        myTextOri = GetComponent<TextMesh>().text;
    }
        void Start () {
        
        
        this.GetComponent<Renderer>().sortingLayerName = "Tombol";
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetString(string text) {
        
        GetComponent<TextMesh>().text = text;
    }
}
