using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour
{

    [SerializeField]
    private RectTransform healthBerRect;
    [SerializeField]
    private Text healtText;

    private void Start()
    {

    }

    public void SetHealth(int _cur, int _max)
    {
        float _value = (float)_cur / _max;

        healthBerRect.localScale = new Vector3(_value, healthBerRect.localScale.y, healthBerRect.localScale.z);
        healtText.text = _cur + "/" + _max + " HP";
    }

}
