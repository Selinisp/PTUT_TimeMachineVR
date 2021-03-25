using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardKeyValid : MonoBehaviour
{

    public GameObject VideoController;
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
            VideoController.GetComponent<VideoController>().videoFolder = textScreen.GetComponent<TMPro.TextMeshPro>().text;
            

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
