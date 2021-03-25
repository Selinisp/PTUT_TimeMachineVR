using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScreenController : MonoBehaviour
{
    public int hour = System.DateTime.Now.Hour;
    public int minute = System.DateTime.Now.Minute;

    public int day = System.DateTime.Now.Day;
    public int month = System.DateTime.Now.Month;
    public int year = System.DateTime.Now.Year;

    public int actionId = 0; //0 : hour | 1 : minute | 2 : year | 3 : month | 4 : day

    private void Start()
    {
        UpdateText();
    }
    private void UpdateText()
    {
        string heure = (hour < 10 ? "0" : "") + hour + ":" + (minute < 10 ? "0" : "") + minute;
        string date = (day < 10 ? "0" : "") + day + "/" + (month < 10 ? "0" : "") + month + "/" + year;
        string actuel= "";

        if (actionId == 0) actuel = "MAJ Actuelle : Heures";
        else if(actionId == 1) actuel = "MAJ Actuelle : Minutes";
        else if (actionId == 2) actuel = "MAJ Actuelle : Années";
        else if (actionId == 3) actuel = "MAJ Actuelle : Mois";
        else if (actionId == 4) actuel = "MAJ Actuelle : Jour";

        this.GetComponent<TMPro.TextMeshPro>().text = "Heure : " + heure + "\nDate : " + date + "\n" + actuel; 
    }

    public void showVideo()
    {
       
    }

    public void ButtonValidate()
    {
        if(actionId == 4)
        {
            actionId = 0;
        }
        else
        {
            actionId++;
        }
        UpdateText();
    }

    public void ButtonPlus()
    {
        if(actionId == 0)
        {
            if(hour == 23)
            {
                hour = 0;
            }
            else
            {
                hour++;
            }
        } else if (actionId == 1)
        {
            if (minute == 59)
            {
                minute = 0;
            }
            else
            {
                minute++;
            }
        } else if (actionId == 2)
        {
            year++;
        } else if (actionId == 3)
        {
            if (month == 12)
            {
                month = 1;
            }
            else
            {
                month++;
            }
        } else if (actionId == 4)
        {
            int[] patern = {1,-2,1,0,1,0,1,1,0,1,0,1};

            if(day == (30 + patern[month - 1])) {
                day = 1;
            }
            else
            {
                day++;
            }
        }

            UpdateText();
    }

    public void ButtonMinus()
    {
        if (actionId == 0)
        {
            if (hour == 0)
            {
                hour = 23;
            }
            else
            {
                hour--;
            }
        }
        else if (actionId == 1)
        {
            if (minute == 0)
            {
                minute = 59;
            }
            else
            {
                minute--;
            }
        }
        else if (actionId == 2)
        {
            year--;
        }
        else if (actionId == 3)
        {
            if (month == 1)
            {
                month = 12;
            }
            else
            {
                month--;
            }
        }
        else if (actionId == 4)
        {
            int[] patern = { 1, -2, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1 };

            if (day == 1)
            {
                day = 30 + patern[month - 1];
            }
            else
            {
                day--;
            }
        }

        UpdateText();
    }
}
