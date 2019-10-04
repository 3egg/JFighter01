using UnityEngine;
using Utils;

namespace model
{
    public class ComicsItem : MonoBehaviour
    {
        public void init(Sprite sprite)
        {
            transform.Image().sprite = sprite;
        }
    }
}