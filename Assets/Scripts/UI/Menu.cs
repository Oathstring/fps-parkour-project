using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Oathstring
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Menu[] menus;

        // Start is called before the first frame update
        void Start()
        {
            menus = transform.parent.GetComponentsInChildren<Menu>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void OnClicked()
        {
            this.gameObject.GetComponent<CanvasGroup>().alpha = 1;
            this.gameObject.GetComponent<CanvasGroup>().interactable = true;
            this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;

            for (int i = 0; i < menus.Length; i++)
            {
                if(menus[i] != this)
                {
                    menus[i].GetComponent<CanvasGroup>().alpha = 0;
                    menus[i].GetComponent<CanvasGroup>().interactable = false;
                    menus[i].GetComponent<CanvasGroup>().blocksRaycasts = false;
                }
            }
        } 
    }
}
