using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class Manager : MonoBehaviour {
    InterstitialAd interstitial;

    public Flag dbFlag;//Database monster
    Flag myFlag;//monster yang muncul
    static Manager ins;
    public static Manager Instance { get { return ins; } }
    public bool ReadyPlay;
    public int Name, LastName,tempName;
  public  int MyScore;
    public Font myFont,tutorial;
    string simpanTutorial;
    public GameObject GameOver;
    public float Time;
    float tempTime;
    public Transform Tulisan,waktu;
    public bool Pencet=false;
    // Use this for initialization
    void Start () {
        RequestInterstitial();

        Screen.SetResolution(720, 1280, true);

        tempTime = Time;
        ReadyPlay = false;
        ins = this;
        myFlag = Instantiate(dbFlag)as Flag;//memunculkan monster
        LastName = myFlag.myNumber;
        simpanTutorial = tutorial.myTextOri;
        tutorial.SetString("Remember this food\nand tap to play");
        myFont.SetString("");
       
        waktuScale = waktu.localScale.x;
	}
    float waktuScale;
    // Update is called once per frame
    float Times = 0;
    void Update()
    {
        Times += 1;
        if (Times == 10)
        {
            SoundManager.Instance.PlaySoundBgGamePlay();
        }

        waktu.transform.localScale = new Vector3((Time-myFlag.time)*waktuScale, 1);
        Time = tempTime - (MyScore * 0.07f);
        //    print(name + "asd" + "  " + LastName);
        if (myFlag.time > Time&&!WasGameOver&&!Pencet) {
            IsGameOver();
        }
        if (!WasGameOver&&ReadyPlay)
        {
            tutorial.SetString(simpanTutorial);
            myFont.SetString("SCORE  : "+MyScore + "");
            if (myFlag == null)
            {
                Pencet = false;
                LastName = tempName;//Menyimpan mnama sebelumnya
                myFlag = Instantiate(dbFlag) as Flag;//memunculkan monster
                if (Random.RandomRange(0, 4) == 2) {
                    myFlag.SetAngka(LastName);
                }

                
            }
            else
            {
                tempName = myFlag.myNumber;//menyimpan nama temporary
                Name = myFlag.myNumber;//Menyimpan nama sekarang
            }
        }
        ReadyToPlay();
	}
    void ReadyToPlay() {
        if (Input.GetMouseButtonDown(0) && !ReadyPlay) {
            SoundManager.Instance.PlaySoundStarting();
            ReadyPlay = true;
            Destroy(Tulisan.gameObject);
            Pencet = true;
        }
    }
    public void Benar() {

        if (Name != null && ReadyPlay && myFlag.ReadyToKlik)
        {
            Pencet = true;
        if (Name == LastName)
        {
            MyScore++;
        }
        else {
                IsGameOver();
            }
        }
       // name = "";
    }
    public void Salah()
    {
      
        if (Name != null&&ReadyPlay&&myFlag.ReadyToKlik)
        {
            Pencet = true;
            if (Name != LastName)
            {
                MyScore++;
            }
            else
            {
                IsGameOver();
            }
        }
       // name = "";
    }
    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();


        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 6 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);

       // GUI.Label(rect, "SCORE " + MyScore, style);
    }
    public bool WasGameOver=false;
    void IsGameOver() {
        WasGameOver = true;
        if (MyScore > PlayerPrefs.GetInt("score")) {
            PlayerPrefs.SetInt("score", MyScore);
        }
		PlayerPrefs.SetInt ("intGameOver", PlayerPrefs.GetInt ("intGameOver") + 1);
		Debug.Log (PlayerPrefs.GetInt("intGameOver"));
        Instantiate(GameOver);
		if ((PlayerPrefs.GetInt ("intGameOver")) % 5 == 0) {
			Debug.Log("Yes");
			interstitial.Show ();
		}
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-1969361650840725/2836316493";
#elif UNITY_IPHONE
                string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
#else
                string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }
}
