using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Oathstring
{
    public class LoadingScreen : MonoBehaviour
    {
        private bool startLoadScene = false;
        private CanvasGroup canvasGroup;
        private PlayerController playerController;
        private TextMeshProUGUI[] textMeshProUGUI;
        private Button button;

        private float timer = 0;

        [TextArea][SerializeField] private string endLevelText;

        // Start is called before the first frame update
        void Start()
        {
            startLoadScene = true;
            canvasGroup = GetComponent<CanvasGroup>();
            textMeshProUGUI = GetComponentsInChildren<TextMeshProUGUI>();
            button = GetComponentInChildren<Button>();

            button.gameObject.SetActive(false);

            if(SceneManager.GetActiveScene().name != "Menu")
            {
                playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                playerController.enabled = false;
            }

            else if(SceneManager.GetActiveScene().name == "Menu")
            {
                textMeshProUGUI[1].text = "";
            }

            canvasGroup.alpha = 0;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        // Update is called once per frame
        void Update()
        {
            if(startLoadScene)
            {
                if(timer >= 4)
                {
                    if (SceneManager.GetActiveScene().name != "Menu")
                    {
                        LevelComplete levelComplete = GameObject.FindGameObjectWithTag("CompletedLevel").GetComponent<LevelComplete>();

                        if(levelComplete.GetLevelName() != "") SceneManager.LoadScene(levelComplete.GetLevelName());
                        else 
                        {
                            textMeshProUGUI[0].text = "";
                            textMeshProUGUI[1].text = "";
                            StartCoroutine(TypingEnd());

                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
                        }
                    }

                    else if (SceneManager.GetActiveScene().name == "Menu")
                    {
                        MenuSystem menuSystem = GameObject.Find("Menu System").GetComponent<MenuSystem>();
                        
                        if(menuSystem.GetContinueProgress()) SceneManager.LoadScene(PlayerPrefs.GetString("Level", "Level 1"));
                        else SceneManager.LoadScene("Level 1");
                    }

                    startLoadScene = false;
                    timer = 0;
                }

                else if(timer <= 4)
                {
                    canvasGroup.alpha += Time.deltaTime / 1;
                    timer += Time.deltaTime / 1;
                }
            }
        }

        private IEnumerator TypingEnd()
        {
            foreach(char c in endLevelText.ToCharArray())
            {
                textMeshProUGUI[1].text += c;
                
                yield return new WaitForSeconds(0.3f);

                if(textMeshProUGUI[1].text == endLevelText) button.gameObject.SetActive(true);
            }
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
