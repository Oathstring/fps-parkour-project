using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Oathstring
{
    public class LevelComplete : MonoBehaviour
    {
        [SerializeField] private string loadNextLevel;

        public string GetLevelName()
        {
            return loadNextLevel;
        }
    }
}
