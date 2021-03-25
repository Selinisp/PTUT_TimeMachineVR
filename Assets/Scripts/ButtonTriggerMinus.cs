using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggerMinus : MonoBehaviour
{
    public GameObject textScreen;
    bool pressed = false;

    public GameObject bas;

    public Material materialOrigin;
    public Material materialPress;

    private void OnTriggerEnter(Collider other)
    {
        if (!pressed && (other.gameObject.name == "CustomHandLeft" || other.gameObject.name == "CustomHandRight"))
        {
            pressed = true;
            textScreen.GetComponent<ScreenController>().ButtonMinus();
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
