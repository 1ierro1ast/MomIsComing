using System;
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
        [SerializeField] private GameObject _screenFader;
        
        

        

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
            _finalCamera.SetActive(true);
            _screenFader.SetActive(true);
            _screenFader.GetComponent<Image>().CrossFadeAlpha(0, 30, true);
            _mainCamera.SetActive(false);
            _badFamily.SetActive(true);
        }

        public void MomGoHappy()
        {
            _finalCamera.SetActive(true);
            _screenFader.SetActive(true);
            _screenFader.GetComponent<Image>().CrossFadeAlpha(0, 30, true);
            _mainCamera.SetActive(false);
            _goodFamily.SetActive(true);
        }
        
        
    }
}
