using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteEffects : MonoBehaviour
{
    private float delayTime = 0.5f;
    private SpriteRenderer render;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }
    public IEnumerator FadeTo(float _aValue, float _aTime, bool _shouldDestroy)
    {
        float alpha = render.material.color.a;

        if (_aValue >= 1)
        {
            alpha = 0;
        }

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / _aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, _aValue, t));
            render.material.color = newColor;
            yield return null;
        }

        if (_shouldDestroy)
        {
            Destroy(gameObject);
        }

    }
    public IEnumerator Blink(int _blinkTimes, bool _shouldDestroy)
    {
        for (var i = 0; i < _blinkTimes; i++)
        {

            render.enabled = false;
            yield return new WaitForSeconds(delayTime / 2);
            render.enabled = true;
            yield return new WaitForSeconds(delayTime);

        }

        if (_shouldDestroy)
        {
            Destroy(gameObject);
        }
    }
    public IEnumerator FlashRed(Color _originalColor, int _flashTime, bool _shouldDestroy)
    {
        for (var i = 0; i < _flashTime; i++)
        {

            render.material.color = Color.red;
            yield return new WaitForSeconds(delayTime / 2);
            render.material.color = _originalColor;
            yield return new WaitForSeconds(delayTime);

        }

        if (_shouldDestroy)
        {
            Destroy(gameObject);
        }

    }

}
