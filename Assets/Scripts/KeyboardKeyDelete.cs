using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardKeyDelete : MonoBehaviour
{

    public GameObject textScreen;

    public Material materialOrigin;
    public Material materialPress;

    private bool pressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!pressed && (other.gameObject.name == "CustomHandLeft" || other.gameObject.name == "CustomHandRight"))
        {
            pressed = true;

            this.GetComponent<MeshRenderer>().material = materialPress;

            textScreen.GetComponent<TMPro.TextMeshPro>().text = textScreen.GetComponent<TMPro.TextMeshPro>().text.Remove(textScreen.GetComponent<TMPro.TextMeshPro>().text.Length - 1);

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
