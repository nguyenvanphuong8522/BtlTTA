using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CityPeople
{
    public class AnimatorController : MonoBehaviour
    {
        public List<AnimationTarget> AnimationTargets;
        [SerializeField]
        private Animator animator;
        public AnimationClip firstDefault;
        public AnimationClip endDefault;
        public void PlayClip(int id, bool _2nd)
        {
            if(id > AnimationTargets.Count - 1)
            {
                id = 0;
            }
            AnimationClip cl;
            if (_2nd)
            {
                if(AnimationTargets[id].firstClip == null)
                {
                    cl = firstDefault;
                }
                else
                {
                    cl = AnimationTargets[id].firstClip;
                }
            }
            else
            {
                if (AnimationTargets[id].endClip == null)
                {
                    cl = endDefault;
                }
                else
                {
                    cl = AnimationTargets[id].endClip;
                }
            }
                
            animator.Play(cl.name);
        }
    }
    [Serializable]
    public struct AnimationTarget
    {
        public int duration;
        public AnimationClip firstClip;
        public AnimationClip endClip;
        public float speed;
    }
}
