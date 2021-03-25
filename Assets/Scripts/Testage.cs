using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using System.Text.RegularExpressions;

public class Testage : MonoBehaviour
{
    public GameObject flatScreen;
    public GameObject skyboxScreen;

    public GameObject textScreen;

    public bool VID = false;

    public string videoFolder = @"http://127.0.0.1/Files/";

    private void Start()
    {
        searchVideo();
    }

    public void searchVideo()
    {
        int year = textScreen.GetComponent<ScreenController>().year;
        int month = textScreen.GetComponent<ScreenController>().month;
        int day = textScreen.GetComponent<ScreenController>().day;
        int hour = textScreen.GetComponent<ScreenController>().hour;
        int minute = textScreen.GetComponent<ScreenController>().minute;
        DateTime time = new DateTime(year, month, day, hour, minute, 0);

        string fileName = GetClosestVideoFile(time);

        Debug.Log(videoFolder + fileName);

        if (VID)
        {
            flatScreen.GetComponent<UnityEngine.Video.VideoPlayer>().url = videoFolder + "\\" + fileName;
            textScreen.GetComponent<TMPro.TextMeshPro>().text = "Vidéo en cours de lecture sur l'écran plat !";
        }
        else
        {
            skyboxScreen.GetComponent<UnityEngine.Video.VideoPlayer>().url = videoFolder + "\\" + fileName;
            textScreen.GetComponent<TMPro.TextMeshPro>().text = "Sortez du Tardis pour voir la vidéo en 360° !";
        }
    }

    public string GetClosestVideoFile(DateTime time)
    {
        var request = (HttpWebRequest)WebRequest.Create(@"http://127.0.0.1/files");
        var response = (HttpWebResponse)request.GetResponse();

        string minname = "";
        long mintime = -1;
        long tpmp = ((DateTimeOffset)time).ToUnixTimeSeconds();

        using (var reader = new StreamReader(response.GetResponseStream()))
        {

            string body = reader.ReadToEnd();
            string pattern = "(VID|360)_[0-9]{8}_[0-9]{5,6}[.]mp4";
            foreach (Match match in Regex.Matches(body, pattern))
            {
                string[] tab = match.Value.Split('_');
                try
                {
                    //Debug.Log("Year : " + tab[1].Substring(0, 4) + "\nMonth : " + tab[1].Substring(4, 2) + "\nDay : " + tab[1].Substring(6, 2) + "\nHours : " + tab[2].Substring(0, 2) + "\nMinutes : " + tab[2].Substring(2, 2) + "\nSeconds : " + 0);
                    int vidyear = Int32.Parse(tab[1].Substring(0, 4));
                    int vidmonth = Int32.Parse(tab[1].Substring(4, 2));
                    int vidday = Int32.Parse(tab[1].Substring(6, 2));
                    int vidhour = Int32.Parse(tab[2].Substring(0, 2));
                    int vidminute = Int32.Parse(tab[2].Substring(2, 2));
                    if (vidmonth > 0 && vidmonth < 13 && vidday > 0 && vidday < 32 && vidhour >= 0 && vidhour < 24 && vidminute >= 0 && vidminute < 60)
                    {
                        DateTime viddate = new DateTime(vidyear, vidmonth, vidday, vidhour, vidminute, 0);
                        long tmp = ((DateTimeOffset)viddate).ToUnixTimeSeconds();
                        if (mintime == -1 || Math.Abs(tmp - tpmp) < Math.Abs(mintime - tpmp))
                        {
                            mintime = tmp;
                            minname = match.Value;
                            VID = match.Value.StartsWith("VID");
                        }
                    }
                }
                catch (System.Exception)
                {
                    Debug.Log("Parsing failed");
                    throw;
                }
            }

        }

        return minname;
    }
}
