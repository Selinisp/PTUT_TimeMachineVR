using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardKeyScript : MonoBehaviour
{

    public GameObject textScreen;
    public char theChar;

    public Material materialOrigin;
    public Material materialPress;

    private bool pressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!pressed && (other.gameObject.name == "CustomHandLeft" || other.gameObject.name == "CustomHandRight"))
        {
            pressed = true;

            this.GetComponent<MeshRenderer>().material = materialPress;

            textScreen.GetComponent<TMPro.TextMeshPro>().text += theChar;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (pressed && (other.gameObject.name == "CustomHandLeft" || other.gameObject.name == "CustomHandRight"))
        {
            pressed = false;
            this.GetComponent<MeshRenderer>().material = materialOrigin;
        }
    }
}
