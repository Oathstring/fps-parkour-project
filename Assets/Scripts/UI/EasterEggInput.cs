using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Oathstring
{
    public class EasterEggInput : MonoBehaviour
    {
        [SerializeField] private GameObject easterEggLoader;
        [SerializeField] private string[] easterEggs;

        private bool easterEggLoaded = false;
        private TMP_InputField inputField;

        private void Start()
        {
            inputField = GetComponent<TMP_InputField>();
        }

        public void EasterEggEntered()
        {
            for(int i = 0; i < easterEggs.Length; i++)
            {
                if (!easterEggLoaded && inputField.text == easterEggs[i])
                {
                    GameObject easterEggLoader = Instantiate(this.easterEggLoader);

                    EasterEgg easterEgg = easterEggLoader.GetComponent<EasterEgg>();
                    easterEgg.SetEasterEgg(inputField.text);

                    inputField.text = "OK";

                    DontDestroyOnLoad(easterEggLoader);
                    easterEggLoaded = true;
                }
            }
        }

        public void OnSelected()
        {
            if(!easterEggLoaded) 
            {
                inputField.text = "";
                inputField.placeholder.GetComponent<TextMeshProUGUI>().text = "Enter text...";
            }
        }

        public void OnLoadedEasterEgg()
        {
            if(easterEggLoaded) inputField.text = "OK";
        }
    }
}
