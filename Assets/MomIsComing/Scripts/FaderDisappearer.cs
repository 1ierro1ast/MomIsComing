using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace MomIsComing.Scripts
{
    public class FaderDisappearer : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        public void HideFader()
        {
            _image.CrossFadeAlpha(0,0,true);
        }
    }
}