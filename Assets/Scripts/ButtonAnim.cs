using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animation>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    
    }
}
