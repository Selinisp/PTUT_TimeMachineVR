using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggerSearch : MonoBehaviour
{

    public GameObject videoController;

    public GameObject textScreen;

    public GameObject bas;

    public Material materialOrigin;
    public Material materialPress;

    bool pressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!pressed && (other.gameObject.name == "CustomHandLeft" || other.gameObject.name == "CustomHandRight"))
        {
            pressed = true;
            videoController.GetComponent<VideoController>().searchVideo();
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
