using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _healthFill;

    //Updates the fill amount property of the image in the Canvas following the health percentage field, called from Health class.
    void Update()
    {
        _healthFill.fillAmount = _health.HealthPercentage;
    }
}
