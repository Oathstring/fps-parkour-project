using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Oathstring
{
    public class MenuSystem : MonoBehaviour
    {
        [SerializeField] private Button continueButton;
        [SerializeField] private TMP_InputField easterEggInputField;

        private bool continueProgress;
        private LoadingScreenHandler loadingScreenHandler;

        private void Start()
        {
            loadingScreenHandler = GameObject.Find("UI Instantiate").GetComponent<LoadingScreenHandler>();
        }

        private void Update()
        {
            continueButton.interactable = PlayerPrefs.HasKey("Level");

            ToggleInputField(Input.GetKeyDown(KeyCode.BackQuote));
        }

        private void ToggleInputField(bool input)
        {
            if(input)
            {
                easterEggInputField.GetComponent<Image>().enabled = true;
            }
        }

        public void StartGame()
        {
            continueProgress = false;
            loadingScreenHandler.InstantiateLoadingScreen();
        }

        public void LoadGame()
        {
            continueProgress = true;
            loadingScreenHandler.InstantiateLoadingScreen();
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void DeleteProgress()
        {
            PlayerPrefs.DeleteKey("Level");
        }

        public bool GetContinueProgress()
        {
            return continueProgress;
        }
    }
}
