using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggerEvent : MonoBehaviour
{

    public GameObject videoPlayerGameObject;
    private bool pressed = false;

    public GameObject bas;

    public Material materialOrigin;
    public Material materialPress;

    public GameObject[] pauseGameObjects;
    public GameObject[] playGameObjects;

    private void OnTriggerEnter(Collider other)
    {
        if(!pressed && (other.gameObject.name == "CustomHandLeft" || other.gameObject.name == "CustomHandRight"))
        {
            pressed = true;
            var videoPlayer = videoPlayerGameObject.GetComponent<UnityEngine.Video.VideoPlayer>();
            bas.GetComponent<MeshRenderer>().material = materialPress;

            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
                foreach(GameObject elems in pauseGameObjects)
                {
                    elems.GetComponent<MeshRenderer>().enabled = false;
                }
                foreach (GameObject elems in playGameObjects)
                {
                    elems.GetComponent<MeshRenderer>().enabled = true;
                }
            }
            else
            {
                videoPlayer.Play();
                foreach (GameObject elems in pauseGameObjects)
                {
                    elems.GetComponent<MeshRenderer>().enabled = true;
                }
                foreach (GameObject elems in playGameObjects)
                {
                    elems.GetComponent<MeshRenderer>().enabled = false;
                }
            }

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
