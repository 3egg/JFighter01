using System;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Model
{
    public class ComicsPage : MonoBehaviour
    {
        public Sprite[] numSprites;
        private Image _indexImage;

        private void Start()
        {
            _indexImage = transform.Find("Index").Image();
            numSprites = GetComponent<ComicsPage>().numSprites;
        }

        public void showNumPage(int index)
        {
            if (index >= numSprites.Length)
            {
                Debug.LogError("index > numSprites length");
                return;
            }
            else
            {
                _indexImage.sprite = numSprites[index];
            }
        }
    }
}