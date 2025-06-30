using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverUISound : MonoBehaviour, IPointerEnterHandler
{
    public AudioManager audioManager;

    private void Awake()
    {
        GameObject manager = GameObject.Find("AudioManager");
        audioManager = manager.GetComponent<AudioManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioManager.Play("HoverUI");
    }
}
