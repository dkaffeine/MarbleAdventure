using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class Tooltips : MonoBehaviour
    {

        public Image fadingImage;

        public Text Line1;

        public Text Line2;

        public Text Line3;

        public Text Line4;

        public Text Line5;

        private Color fadingImageColor;

        private bool fadeOut;

        private bool fadeIn;

        private float fadeTime;

        private const float fadePeriod = 0.2f;

        private const float maximumFading = 0.25f;
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
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
                if (fadeTime >= GetFadeAmplitude())
                {
                    fadeTime = GetFadeAmplitude();
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

        public float GetFadeAmplitude()
        {
            return maximumFading;
        }
    }
}

