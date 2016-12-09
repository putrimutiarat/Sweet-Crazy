using UnityEngine;
using System.Collections;

public class AmbilData : MonoBehaviour {
    public CHPHP Data;
	// Use this for initialization
	void Start () {
        // Data = new CHPHP();
        try
        {
            this.GetComponent<Renderer>().sortingLayerName = "PalingAtas";
        }
        catch (System.Exception) {
            print(this.name + "   Error CUkk");
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        switch (this.gameObject.name) {
            case "nama1":
                this.GetComponent<TextMesh>().text = "1 "+Data.Data[1]+"";
                break;
            case "score1":
                this.GetComponent<TextMesh>().text = Data.Data[2] + "";
                break;
            case "nama2": this.GetComponent<TextMesh>().text = "2 " + Data.Data[4] + ""; break;
            case "score2": this.GetComponent<TextMesh>().text = Data.Data[5] + ""; break;
            case "nama3": this.GetComponent<TextMesh>().text = "3 " + Data.Data[7] + ""; break;
            case "score3": this.GetComponent<TextMesh>().text = Data.Data[8] + ""; break;
            case "nama4": this.GetComponent<TextMesh>().text = "4 " + Data.Data[10] + ""; break;
            case "score4": this.GetComponent<TextMesh>().text = Data.Data[11] + ""; break;
            case "nama5": this.GetComponent<TextMesh>().text = "5 " + Data.Data[13] + ""; break;
            case "score5": this.GetComponent<TextMesh>().text = Data.Data[14] + ""; break;
        }
	}
}
