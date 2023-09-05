using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Oathstring
{
    public class WelcomeTittleHandler : MonoBehaviour
    {
        public delegate void WelcomeTittleHandlerEvent(object sender, EventArgs eventArgs);

        public WelcomeTittleHandlerEvent welcomeTittleHandlerEvent;

        [SerializeField] private GameObject welcomeTittlePrefab;

        [TextArea]
        [SerializeField] private string levelName;

        // Start is called before the first frame update
        void Start()
        {
            Instantiate(welcomeTittlePrefab, GameObject.Find("Canvas").transform);
        }

        // Update is called once per frame
        void Update()
        {
            welcomeTittleHandlerEvent?.Invoke(this, EventArgs.Empty);
        }

        public string GetLevelName()
        {
            return levelName;
        }
    }
}
