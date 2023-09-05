using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Oathstring
{
    public class SoundHandler : MonoBehaviour
    {
        private bool musicOn;
        private float musicVolumeSet;

        private Toggle musicToggle;
        private Slider musicSlider;
        private AudioSource musicSource;

        [SerializeField]private AudioSource[] sfxSources;

        // Start is called before the first frame update
        void Start()
        {
            InitUIs();

            InitAudioSources();

            musicOn = Convert.ToBoolean(PlayerPrefs.GetInt("Music On", 1));
            musicVolumeSet = PlayerPrefs.GetFloat("Music Volume", 0.2f);

            if (musicSource)
            {
                musicSource.mute = !musicOn;
                musicSource.volume = musicVolumeSet;

                if (musicToggle) musicToggle.isOn = musicOn;
                if (musicSlider) musicSlider.value = musicVolumeSet;
            }
        }

        void InitUIs()
        {
            GameObject mToggle = GameObject.Find("Music Toggle");
            if (mToggle) musicToggle = mToggle.GetComponent<Toggle>();

            GameObject mSlider = GameObject.Find("Music Volume Slider");
            if (mSlider) musicSlider = mSlider.GetComponent<Slider>();
        }

        void InitAudioSources()
        {
            musicSource = GameObject.Find("Music Source").GetComponent<AudioSource>();

            GameObject[] sfxObjs = GameObject.FindGameObjectsWithTag("SFX");

            if(sfxObjs != null)
            {
                sfxSources = new AudioSource[sfxObjs.Length];
                for (int i = 0; i < sfxObjs.Length; i++) sfxSources[i] = sfxObjs[i].GetComponent<AudioSource>();
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void OnChangedValue()
        {
            musicOn = musicToggle.isOn;

            PlayerPrefs.SetInt("Music On", Convert.ToInt32(musicOn));

            if (musicSource)
            {
                musicSource.mute = !musicOn;
                musicSource.volume = musicVolumeSet;
            }
        }

        public void OnChancedSlider()
        {
            musicVolumeSet = musicSlider.value;

            PlayerPrefs.SetFloat("Music Volume", musicVolumeSet);

            if (musicSource)
            {
                musicSource.mute = !musicOn;
                musicSource.volume = musicVolumeSet;
            }
        }

        public void ResetAllSettings()
        {
            musicSlider.value = 0.2f;
            musicToggle.isOn = true;
        }
    }
}
