using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;

namespace Oathstring
{
    public class WelcomeTittle : MonoBehaviour
    {
        private WelcomeTittleHandler welcomeTittleHandler;
        private TextMeshProUGUI[] tittles;
        private CanvasGroup canvasGroup;
        private bool fadeOut;
        private float timerToFadeOut = 8;

        // Start is called before the first frame update
        void Start()
        {
            welcomeTittleHandler = GameObject.Find("UI Instantiate").GetComponent<WelcomeTittleHandler>();
            welcomeTittleHandler.welcomeTittleHandlerEvent += OnStartedWelcomeTittle;

            tittles = GetComponentsInChildren<TextMeshProUGUI>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnStartedWelcomeTittle(object sender, EventArgs eventArgs)
        {
            tittles[0].text = SceneManager.GetActiveScene().name;
            tittles[1].text = welcomeTittleHandler.GetLevelName();

            if (fadeOut) canvasGroup.alpha -= Time.deltaTime / 2;
            else 
            {
                canvasGroup.alpha += Time.deltaTime / 1;
                timerToFadeOut -= Time.deltaTime / 1;

                if (timerToFadeOut <= 0) 
                {
                    timerToFadeOut = 0;
                    fadeOut = true;
                }
            }

        }

        private void OnDestroy() 
        {
            welcomeTittleHandler.welcomeTittleHandlerEvent -= OnStartedWelcomeTittle;

        }
    }
}
