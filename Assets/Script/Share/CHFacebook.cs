using UnityEngine;
using System.Collections;

public class CHFacebook : MonoBehaviour
{

    const string AppId = "";
    const string ShareUrl = "http://www.facebook.com/dialog/feed";
    public static void ShareFB(string link, string pictureLink, string name,
    string caption, string description, string redirectUri)
    {
        Application.OpenURL(ShareUrl +
            "?app_id=" + "972220786130378" +
            "&amp;link=" + WWW.EscapeURL(link) +
            "&amp;picture=" + WWW.EscapeURL(pictureLink) +
            "&amp;name=" + WWW.EscapeURL(name) +
            "&amp;caption=" + WWW.EscapeURL(caption) +
            "&amp;description=" + WWW.EscapeURL(description) +
            "&amp;redirect_uri=" + WWW.EscapeURL(redirectUri));
    }
    public static void Share(string link)
    {
        Application.OpenURL(ShareUrl +
            "?app_id=" + AppId +
            "&amp;link=" + WWW.EscapeURL(link));
    }

    public void cek()
    {

    }
    const string Address = "http://twitter.com/intent/tweet";

    public static void ShareTwitter(string text, string url,
        string related, string lang = "en")
    {
        Application.OpenURL(Address +
            "?text=" + WWW.EscapeURL(text) +
            "&amp;url=" + WWW.EscapeURL(url) +
            "&amp;related=" + WWW.EscapeURL(related) +
            "&amp;lang=" + WWW.EscapeURL(lang));
    }
}
