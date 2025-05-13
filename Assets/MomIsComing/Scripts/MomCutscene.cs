using System;
using DG.Tweening;
using MomIsComing.Scripts.Ui;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

namespace MomIsComing.Scripts
{
    public class MomCutscene : MonoBehaviour
    {
        [SerializeField] private PlayableDirector _playableDirector;
        [SerializeField] private TimelineAsset _momEnterAngryTimeline;
        [SerializeField] private TimelineAsset _momEnterHappyTimeline;
        [SerializeField] private GameObject _badFamily;
        [SerializeField] private GameObject _goodFamily;
        [SerializeField] private GameObject _mainCamera;
        [SerializeField] private GameObject _finalCamera;
        [SerializeField] private Image _screenFader;
        [SerializeField] private float _delay = 1;


        public void MomEnter(float evaluationResult)
        {
            if (evaluationResult >= 0.85f)
            {
                _playableDirector.Play(_momEnterHappyTimeline);
            }
            else
            {
                _playableDirector.Play(_momEnterAngryTimeline);
            }
        }

        public void MomGoAngry()
        {
            Cursor.lockState = CursorLockMode.None;

            _finalCamera.SetActive(true);
            _screenFader.gameObject.SetActive(true);
            _screenFader.CrossFadeAlpha(0, 1, true);
            _mainCamera.SetActive(false);
            _badFamily.SetActive(true);
            _goodFamily.SetActive(false);

            DOVirtual.DelayedCall(_delay, () =>
            {
                RootCanvas.Instance.LosePopup.Show();
                Cursor.visible = true;
            });
        }

        public void MomGoHappy()
        {
            Cursor.lockState = CursorLockMode.None;

            _finalCamera.SetActive(true);
            _screenFader.gameObject.SetActive(true);
            _screenFader.CrossFadeAlpha(0, 1, true);
            _mainCamera.SetActive(false);
            _goodFamily.SetActive(true);
            _badFamily.SetActive(false);

            DOVirtual.DelayedCall(_delay, () =>
            {
                RootCanvas.Instance.WinPopup.Show();
                Cursor.visible = true;
            });
        }
    }
}