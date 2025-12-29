using System.Globalization;
using MomIsComing.Scripts.Abstractions;
using MomIsComing.Scripts.UsefulExtensions.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MomIsComing.Scripts.Ui.Popups
{
    public class TimerPopup : BasePopup
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _timeView;

        private ITimer _timer;
        private string _label;

        public void Construct(ITimer timer, string label)
        {
            _label = label;
            _timer = timer;
        }

        protected override void OnShownCallback()
        {
            base.OnShownCallback();
            if(_timer != null)
                _timer.Initialize(UpdateView);
        }

        protected override void OnHideCallback()
        {
            base.OnHideCallback();
            if(_timer != null)
                _timer.Deinitialize();
        }

        private void UpdateView(float currentValue, float maxValue)
        {
            _slider.value = 1 - (currentValue / maxValue);
            _timeView.text = string.Format(_label, (maxValue - currentValue).FormatTime());
        }
    }
}