using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider _slider;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthbar(int hp)
    {
        _slider.value = (float)hp/100;
    }
}
