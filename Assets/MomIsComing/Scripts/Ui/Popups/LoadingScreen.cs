using System;

namespace MomIsComing.Scripts.Ui.Popups
{
    public class LoadingScreen : BasePopup
    {
        private Action _callback;

        public void SetCallback(Action callback)
        {
            _callback = callback;
        }

        protected override void OnShownCallback()
        {
            base.OnShownCallback();
            _callback?.Invoke();
        }
    }
}