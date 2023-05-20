using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    [SerializeField] Image aim;
    [SerializeField] Image healthBarFull;
    [SerializeField] Image energyBarFull;
    //[SerializeField] GameObject pauseModePanel;
    //[SerializeField] GameObject playModePanel;
    private float coefficientHealth;
    private float coefficientEnergy;
    private float maxHP;
    private float maxEnergy;


    private void Start()
    {
        GetDefaultStates();
        CalculateHealthBar();
        CalculateEnergyBar();
    }

    public void CalculateHealthBar()
    {
        coefficientHealth = healthBarFull.fillAmount / maxHP;
    }

    public void CalculateEnergyBar()
    {
        coefficientEnergy = energyBarFull.fillAmount / maxEnergy;
    }

    public void UpdateHealthBar(float hp)
    {
        healthBarFull.fillAmount = coefficientHealth * hp;
    }

    public void UpdateEnergyBar(float energy)
    {
        energyBarFull.fillAmount = coefficientEnergy * energy;
    }

    public void MoveAim()
    {
        aim.gameObject.transform.DOScale(1.2f, 0.25f).OnComplete(() => transform.DOScale(1.0f, 0.25f));
    }

    private void GetDefaultStates()
    {
        maxHP = GameSettings.Instance.GetMaxPlayerHealth();
        maxEnergy = GameSettings.Instance.GetMaxEnergy();
    }



}
