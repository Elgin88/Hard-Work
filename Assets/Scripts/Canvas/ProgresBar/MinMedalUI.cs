using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MinMedalUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _delay;

    private WaitForSeconds _delayWFS;
    private Coroutine _showImage;

    private void OnEnable()
    {
        _image.gameObject.SetActive(false);
        _delayWFS = new WaitForSeconds(_delay);

        _showImage = StartCoroutine(ShowImage());
    }

    private IEnumerator ShowImage()
    {
        while (true)
        {
            yield return _delayWFS;

            _image.gameObject.SetActive(true);
            StopCoroutine(_showImage);
        }
    }
}