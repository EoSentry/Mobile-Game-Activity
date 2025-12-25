using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimationSetup> animationSetups;

    public enum AnimationType
    {
        IDLE,
        RUN,
        DEAD
    }

    public void Play(AnimationType animationType, float currentSpeed = 1f)
    {
        foreach(var animation in animationSetups)
        {
            if(animation.type == animationType)
            {
                animator.SetTrigger(animation.trigger);
                animator.speed = animation.speed * currentSpeed;
                break;
            }
        }
    }

}
[System.Serializable]
public class AnimationSetup
{
    public AnimationManager.AnimationType type;
    public string trigger;
    public float speed = 1;
}