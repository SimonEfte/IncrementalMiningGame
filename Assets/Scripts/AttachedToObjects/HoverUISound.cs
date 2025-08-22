using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverUISound : MonoBehaviour, IPointerEnterHandler
{
    public AudioManager audioManager;

    bool isCard;

    private void Awake()
    {
        GameObject manager = GameObject.Find("AudioManager");
        audioManager = manager.GetComponent<AudioManager>();

        if(gameObject.tag == "Card")
        {
            isCard = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (MobileAndTesting.isMobile == true) { return; }

        if (isCard == true) { audioManager.Play("CardHover"); }
        else { audioManager.Play("HoverUI"); }
    }
}
