using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExitInto360 : MonoBehaviour
{

    public GameObject player;
    public GameObject spawnExterior;

    public GameObject skyboxPlayer;

    public GameObject tardis;

    bool pressed = false;
    void Update()
    {
        if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5 || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5)
        {
            if (pressed)
            {
                tardis.SetActive(false);
                player.transform.position = spawnExterior.transform.position;
                skyboxPlayer.GetComponent<UnityEngine.Video.VideoPlayer>().Play();
                pressed = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!pressed && (other.gameObject.name == "CustomHandLeft" || other.gameObject.name == "CustomHandRight"))
        {
            pressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(pressed && (other.gameObject.name == "CustomHandLeft" || other.gameObject.name == "CustomHandRight"))
        {
            pressed = false;
        }
    }

}
