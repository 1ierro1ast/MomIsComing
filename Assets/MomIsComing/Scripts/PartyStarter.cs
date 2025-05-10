using UnityEngine;
using Dreamteck.Splines;

namespace MomIsComing.Scripts
{
    public class PartyStarter : MonoBehaviour
    {
        [SerializeField] private float _cutsceneLength = 2;
        [SerializeField] private SplineFollower _splineFollower;
        [SerializeField] private Animator _door;

        public float CutsceneLength => _cutsceneLength;


        public void StartCutscene()
        {
            _splineFollower.followSpeed = _splineFollower.CalculateLength(0, 1, true) / _cutsceneLength;
            _door.SetBool("Open", true );
            _splineFollower.GetComponentInChildren<ParticleSystem>().Play();
            _splineFollower.follow = true;
        }

        public void StopCutscene()
        {
            _door.SetBool("Open", false );
            _splineFollower.follow = false;
            _splineFollower.SetPercent(0);
            _splineFollower.GetComponentInChildren<ParticleSystem>().Stop();
        }
    }
}