using System.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSMB : MonoBehaviour
{

    public GameObject bas;

    public Material materialOrigin;
    public Material materialPress;

    bool pressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!pressed && (other.gameObject.name == "CustomHandLeft" || other.gameObject.name == "CustomHandRight"))
        {

            NetworkCredential theNetworkCredential = new NetworkCredential("ptutvr", "Cf6fje7.9DS9");
            CredentialCache theNetcache = new CredentialCache();
            theNetcache.Add(new Uri(@"\\lacie5big.iutbourg.univ-lyon1.fr\"), "Basic", theNetworkCredential);

            string[] theFolders = System.IO.Directory.GetDirectories(@"\\lacie5big.iutbourg.univ-lyon1.fr\ptutvr");

            for (int i = 0; i < theFolders.Length; ++i)
            {
                Debug.Log(theFolders[i]);
            }

        pressed = true;
            bas.GetComponent<MeshRenderer>().material = materialPress;   
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (pressed && (other.gameObject.name == "CustomHandLeft" || other.gameObject.name == "CustomHandRight"))
        {
            pressed = false;
            bas.GetComponent<MeshRenderer>().material = materialOrigin;
        }
    }
}
