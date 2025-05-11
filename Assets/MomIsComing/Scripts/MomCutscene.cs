using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace MomIsComing.Scripts
{
    public class MomCutscene : MonoBehaviour
    {
        [SerializeField] private PlayableDirector _playableDirector;
        [SerializeField] private TimelineAsset _momEnterAngryTimeline;
        [SerializeField] private TimelineAsset _momEnterHappyTimeline;


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
            throw new System.NotImplementedException();
        }

        public void MomGoHappy()
        {
            throw new System.NotImplementedException();
        }
    }
}
