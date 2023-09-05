using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Oathstring
{
    public class LoadingScreenHandler : MonoBehaviour
    {
        [SerializeField] private GameObject LoadingScreen;

        public void InstantiateLoadingScreen()
        {
            Instantiate(LoadingScreen, GameObject.Find("Canvas").transform);
        }
    }
}
