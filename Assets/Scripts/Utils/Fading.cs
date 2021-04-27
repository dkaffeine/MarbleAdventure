using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{

    public Image fadingImage;

    private Color fadingImageColor;

    private bool fadeOut;

    private bool fadeIn;

    private float fadeTime;

    private const float fadePeriod = 2.0f;

    void Awake()
    {
        fadingImageColor = fadingImage.color;
        fadeOut = false;
        fadeIn = false;
        fadeTime = fadingImageColor.a;
    }

    void Update()
    {
        if (fadeOut)
        {
            fadeTime -= Time.deltaTime / GetFadePeriod();
            if (fadeTime <= 0f)
            {
                fadeTime = 0f;
                fadeOut = false;
                fadingImage.gameObject.SetActive(false);
            }
        }

        if (fadeIn)
        {
            fadingImage.gameObject.SetActive(true);
            fadeTime += Time.deltaTime / GetFadePeriod();
            if (fadeTime >= 1f)
            {
                fadeTime = 1f;
                fadeIn = false;
            }
        }

        if (fadingImage.gameObject.activeSelf)
        {
            fadingImageColor.a = fadeTime;
            fadingImage.color = fadingImageColor;
        }
    }


    public void FadeOut()
    {
        fadeOut = true;
        fadeIn = false;
    }

    public void FadeIn()
    {
        fadeIn = true;
        fadeOut = false;
    }

    public float GetFadePeriod()
    {
        return fadePeriod;
    }


}
