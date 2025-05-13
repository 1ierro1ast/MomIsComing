using System;
using UnityEngine;

namespace MomIsComing.Scripts.Ui
{
    public class MenuStartup : MonoBehaviour
    {
        private void Start()
        {
            RootCanvas.Instance.MenuPopup.ShowInstantly();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}