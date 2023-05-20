using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    [SerializeField] Image Aim;

    [SerializeField] Image HealthBarFull;
    [SerializeField] Image EnergyBarFull;
    private float coefficientDamage;
    private float coefficientEnergy;
    private float maxHP;
    private float hp;
    private float maxEnergy;
    private float energy;

    public void CalculateHealthBar()
    {
        coefficientDamage = HealthBarFull.fillAmount / maxHP;
    }

    public void UpdateHealthBar()
    {
        HealthBarFull.fillAmount -= coefficientDamage * hp;
    }

    public void CalculateEnergyBar()
    {
        coefficientEnergy = EnergyBarFull.fillAmount / maxEnergy;
    }

    public void UpdateEnergyBar()
    {
        EnergyBarFull.fillAmount -= coefficientEnergy * energy;
    }

    public void MoveAim()
    {

    }



}
