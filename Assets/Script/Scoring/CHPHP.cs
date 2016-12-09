using UnityEngine;
using System.Collections;
enum data { id, nama, score }
public class CHPHP : MonoBehaviour
{
    private string secretKey = "mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server
    public string linkPostscoring, linkUpdatePlayer, linkGetAllScore, linkGetHighScore;
    public string[] NamaOrang;
    public string[,] Sortingan = new string[3, 100];
    public string[] Data = new string[600];
    bool Ngepost;
    public int PhpScore;
    int data = 0;
    public bool hitung;
    static CHPHP myins;
    public static CHPHP Instance { get { return myins; } }
    void Start()
    {
       // PlayerPrefs.SetString("nama", "Ronaldo");
        print(nama + " Mulai " + SystemInfo.deviceUniqueIdentifier);
       
        nama = PlayerPrefs.GetString("namas");
       // nama = "Kasep";
        id = SystemInfo.deviceUniqueIdentifier+nama;
        print("Begin DB");
        
        Ngepost = false;
        myins = this;
        print(name);
        NamaOrang = new string[600];
        for (int i = 0; i < 200; i++)
        {
            //   StartCoroutine(PostScoring(Random.Range(0,100)+"Yan", Random.Range(0,100)));
            //  StartCoroutine(GetAllScore(i));//Mendapatkan score berdasarkan id

        }
        

        StartCoroutine(CheckData());
        StartCoroutine(GetHighScore());
        StartCoroutine(TestConnection());
    }
   
    void Update()
    {

    }
    public void ChekingData()
    {
        StartCoroutine(CheckData());

    }
    string nama, id;
    IEnumerator CheckData()
    {
        print("CHEKING....");
      
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        form.AddField("action", "send");
        form.AddField("score",PlayerPrefs.GetInt("score"));
        form.AddField("name", nama);
        form.AddField("date", System.DateTime.Now + "");
        string link = "http://pixelclothe.com/crazysweet/check_data.php";
        //  link = linkPostscoring;
        WWW w = new WWW(link, form);

        yield return w;
        if (w.text == "")
        {
            print(w.text + " DataKosong");
            StartCoroutine(PostScoring());
        }
        else
        {
            print("data sudah ada " + w.text);
            StartCoroutine(UpdatePlayer());
        }
    }
    IEnumerator TestConnection()
    {
        WWWForm form = new WWWForm();
       
        form.AddField("id", SystemInfo.deviceUniqueIdentifier + "");
        form.AddField("action", "send");
        form.AddField("score", PlayerPrefs.GetInt("score"));
        form.AddField("name", nama);
        form.AddField("date", System.DateTime.Now + "");
        string link = "http://pixelclothe.com/crazysweet/check_data.php";
        //  link = linkPostscoring;
        WWW w = new WWW(link, form);

        yield return w;

    }
    public void PostingScoring()
    {
        StartCoroutine(PostScoring());
        Ngepost = true;
    }
    string tulisan;
    IEnumerator PostScoring()
    {
        print("Mulai Pengiriman data");
        WWWForm form = new WWWForm();
        form.AddField("id",id+ "");
        form.AddField("action", "send");
        form.AddField("score", PlayerPrefs.GetInt("score"));
        form.AddField("name",nama);
        form.AddField("date", System.DateTime.Now + "");
        string link = "http://pixelclothe.com/crazysweet/add_score.php";
        //  link = linkPostscoring;
        WWW w = new WWW(link, form);

        yield return w;
        if (w.text != "")
        {
            // tulisan = w.text;
            print(w.text);
        }
        else
        {
            //   tulisan = "nothing";
            print("Tidak ada data yang tersimpan");
        }

    }
    IEnumerator UpdatePlayer()
    {
        WWWForm form = new WWWForm();
        print("Update Begin...... ");
        form.AddField("id", id + "");
        form.AddField("action", "send");
        form.AddField("score", PlayerPrefs.GetInt("score"));
        form.AddField("name", nama);
        form.AddField("date", System.DateTime.Now + "");
        form.AddField("wasplay", PlayerPrefs.GetInt("wasplay"));

        string link = "http://pixelclothe.com/crazysweet/update_score.php";
        // link = linkUpdatePlayer;
        WWW w=null;
        if (hitung) {
            w = new WWW(link, form);
        }
        yield return w;
        Ngepost = true;
        // tulisan = "Update Complete";
       // print(w.text);

    }
    IEnumerator GetAllScore(int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("action", "read");
        form.AddField("num", id);
        string link = "http://pixelclothe/crazysweet/load_score.php";
        link = linkGetAllScore;
        WWW w = new WWW(link, form);
        yield return w;

        NamaOrang[id] = w.text;
        PhpScore = int.Parse(w.text);
    }
    IEnumerator GetHighScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("num", "");
        string link = "http://pixelclothe.com/crazysweet/high_score.php";
       // link = linkGetHighScore;
        WWW w = new WWW(link, form);
        yield return w;
        print("High Score Loaded");
        string pecah = w.text;
        print("Data diterbitka"+w.text);

        Data = pecah.Split(' ');

    }


    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 5 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);

        string text = string.Format("");
        if (Ngepost)
        {
            GUI.Label(rect, "" + tulisan, style);
        }


    }

}
