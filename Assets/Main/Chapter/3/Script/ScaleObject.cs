using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    public float duration = 2.0f; // 动画持续时间
    private Vector3 startScale;
    private Vector3 endScale;
    private float elapsedTime = 0f;

    void Start()
    {
        // 记录初始缩放和目标缩放
        startScale = transform.localScale;
        endScale = Vector3.one; // 目标缩放为 (1, 1, 1)
    }

    void Update()
    {
        // 计算已过时间
        elapsedTime += Time.deltaTime;

        // 计算插值比例
        float t = Mathf.Clamp01(elapsedTime / duration);

        // 插值计算缩放值
        transform.localScale = Vector3.Lerp(startScale, endScale, t);

        // 可选：如果你希望动画完成后保持缩放在 (1, 1, 1)，可以取消注释下面这行代码
        // if (t >= 1.0f) enabled = false;
    }
}
