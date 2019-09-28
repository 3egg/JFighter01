using System;
using UnityEngine;

namespace Controller
{
    public class AudioController : MonoBehaviour
    {
        public static AudioController instance { get; private set; } = new AudioController();
        
        [SerializeField] private AudioClip uiBg;
        [SerializeField] private AudioClip uiClick;
        [SerializeField] private AudioClip uiIn;
        [SerializeField] private AudioClip uiOut;
        [SerializeField] private AudioClip uiLogIn;
        [SerializeField] private AudioClip uiLogOut;

        private AudioSource _audioSource;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void playUiBg()
        {
            _audioSource.clip = uiBg;
            _audioSource.loop = true;
            _audioSource.volume = 0.5f;
            _audioSource.Play();
        }

        public void playUiClick()
        {
            _audioSource.PlayOneShot(uiClick,1);
        }
        
        public void playUiIn()
        {
            _audioSource.PlayOneShot(uiIn,1);
        }
        
        public void playUiOut()
        {
            _audioSource.PlayOneShot(uiOut,1);
        }
        
        public void playUiLogOut()
        {
            _audioSource.PlayOneShot(uiLogIn,1);
        }
        
        public void playUiLogIn()
        {
            _audioSource.PlayOneShot(uiLogOut,1);
        }
    }
}