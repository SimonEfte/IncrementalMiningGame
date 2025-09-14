using UnityEngine;
using UnityEngine.UI;

public class AnimRotation : MonoBehaviour
{
    public Animation anim;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    private void OnEnable()
    {
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        if(MobileAndTesting.isMobile == false)
        {
            if(SettingsOptions.isTooltipAnimOn == true)
            {
                anim.Play();
            }
        }
    }
}
