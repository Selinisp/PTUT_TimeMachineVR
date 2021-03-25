using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnterTardis : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnInterior;

    public GameObject tardis;

    public GameObject skyboxPlayer;

    bool pressed = false;
    void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5 || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5)
        {
            if (pressed)
            {
                tardis.SetActive(true);
                player.transform.position = spawnInterior.transform.position;
                skyboxPlayer.GetComponent<UnityEngine.Video.VideoPlayer>().Pause();
                pressed = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!pressed && (other.gameObject.name == "CustomHandLeft" || other.gameObject.name == "CustomHandRight"))
        {
            pressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (pressed && (other.gameObject.name == "CustomHandLeft" || other.gameObject.name == "CustomHandRight"))
        {
            pressed = false;
        }
    }
}
