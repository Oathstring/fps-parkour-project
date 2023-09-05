using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Oathstring
{
    public class EasterEgg : MonoBehaviour
    {
        [SerializeField] string easterEggComfirmed;

        private GameObject[] easterEggObjs;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            easterEggObjs = GameObject.FindGameObjectsWithTag("Easter Egg");

            if (easterEggObjs != null)
            {
                for (int i = 0; i < easterEggObjs.Length; i++)
                {
                    if (easterEggObjs[i].name == easterEggComfirmed)
                    {
                        easterEggObjs[i].transform.localScale = new Vector3(1,1,1);
                    }

                    else //if(easterEggObjs[i].name != easterEggComfirmed)
                    {
                        easterEggObjs[i].transform.localScale = new Vector3(0, 0, 0);
                    }
                }
            }
        }

        public void SetEasterEgg(string input)
        {
            easterEggComfirmed = input;
        }
    }
}
