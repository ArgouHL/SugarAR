using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animation anim;

    void Start()
    {
        // 获取Animation组件
        anim = GetComponent<Animation>();
    }

    // 播放指定名称的动画
    public void PlayAnimation(string animationName)
    {
        if (anim != null)
        {
            anim.Play(animationName);
        }
    }
}
