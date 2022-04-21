using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostEffects : MonoBehaviour //Возможно добавить сильую подстветку при ударе 
{
    private PostProcessVolume _postProcessVolume;
    private Vignette _vignette;
    private Bloom _bloom;
    private float t;
    private float _vignetteSpeed = 2f;
    private void Start()
    {
        _postProcessVolume = GetComponent<PostProcessVolume>();
        _postProcessVolume.profile.TryGetSettings(out _vignette);
        _postProcessVolume.profile.TryGetSettings(out _bloom);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (_vignette.intensity.value != 1)
            {
                _vignette.intensity.value = Mathf.Lerp(_vignette.intensity.value, 1, t);
                t += Time.deltaTime / _vignetteSpeed;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            t = 0;
        }
    }
}
