using System.Collections;
using UnityEngine;

public class MonsterHitEffect : MonoBehaviour
{
    [SerializeField] private MonsterStatus monsterStatus;
    [SerializeField] private Renderer monsterRenderer;
    [SerializeField] private float flashDuration = 0.1f;

    private Color originalColor;
    private Coroutine flashCoroutine;

    private void Awake()
    {
        originalColor = monsterRenderer.material.color;
    }

    private void OnEnable()
    {
        monsterStatus.OnChangeHp += PlayHitEffect;
    }

    private void OnDisable()
    {
        monsterStatus.OnChangeHp -= PlayHitEffect;
    }

    private void PlayHitEffect()
    {
        if (flashCoroutine != null)
            StopCoroutine(flashCoroutine);

        flashCoroutine = StartCoroutine(FlashRed());
    }

    private IEnumerator FlashRed()
    {
        monsterRenderer.material.color = Color.red;

        yield return new WaitForSeconds(flashDuration);

        monsterRenderer.material.color = originalColor;
        flashCoroutine = null;
    }
}