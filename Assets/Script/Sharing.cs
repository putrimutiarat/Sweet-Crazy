using UnityEngine;
using System.Collections;

public class Sharing : MonoBehaviour
{

    const string AppId = "972220786130378";
    const string ShareUrl = "http://www.facebook.com/dialog/feed";
    public void ShareFacebook(string link, string pictureLink, string name, string caption, string description, string redirectUri)
    {
        Application.OpenURL("https://www.facebook.com/dialog/feed" +
            "?app_id=" + AppId +
           "&link=" + link +
    "&picture=" + pictureLink +
    "&name=" + ReplaceSpace(name) +
    "&caption=" + ReplaceSpace(caption) +
  //  "&description=" + ReplaceSpace(description+"DES") +
    "&text=" + ReplaceSpace(description + "tE") +
    "&redirect_uri=https://facebook.com/");
    }
    public static void Share(string link)
    {
        Application.OpenURL(ShareUrl +
            "?app_id=" + AppId +
            "&amp;link=" + WWW.EscapeURL(link));
    }
    static string ReplaceSpace(string val)
    {
        return val.Replace(" ", "%20");
    }
    public void cek()
    {

    }
    const string Address = "http://twitter.com/intent/tweet";

    public void ShareTwitter(string text, string url,
        string related, string lang = "en")
    {
        Application.OpenURL(Address +
            "?text=" + WWW.EscapeURL(text) +
            "&amp;url=" + WWW.EscapeURL(url) +
            "&amp;related=" + WWW.EscapeURL(related) +
            "&amp;lang=" + WWW.EscapeURL(lang));
    }
}
