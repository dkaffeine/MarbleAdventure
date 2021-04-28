using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{

    public class TooltipBox : MonoBehaviour
    {
        /// <summary>
        /// Internal handler to tooptips
        /// </summary>
        public Tooltips tooltips;

        /// <summary>
        /// Lines of text
        /// </summary>
        public string Line1, Line2, Line3, Line4, Line5;

        private void Awake()
        {
            this.tooltips.gameObject.SetActive(false);
            this.tooltips.Line1.text = this.Line1;
            this.tooltips.Line2.text = this.Line2;
            this.tooltips.Line3.text = this.Line3;
            this.tooltips.Line4.text = this.Line4;
            this.tooltips.Line5.text = this.Line5;
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                this.tooltips.gameObject.SetActive(true);
                this.tooltips.FadeIn();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
                this.tooltips.FadeOut();
        }
    }
}
