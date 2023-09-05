using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Oathstring
{
    public class PauseMenu : MonoBehaviour
    {
        private CanvasGroup canvasGroup;
        private PlayerController playerController;

        private void Start() 
        {
            canvasGroup = GetComponent<CanvasGroup>();
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        public void OnEscapePressed(bool input)
        {
            if(input)
            {
                GameObject welcomeTittle = GameObject.Find("Welcome Massege(Clone)");

                playerController.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                Destroy(welcomeTittle);
            }
        }

        public void OnCloseButton()
        {
            playerController.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        public void OnYesButton()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
