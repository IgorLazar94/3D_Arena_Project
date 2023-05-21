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

    [SerializeField] Image hitRedSprite;
    [SerializeField] Image hitBlueSprite;

    [SerializeField] GameObject pauseModePanel;
    [SerializeField] GameObject playModePanel;
    [SerializeField] GameObject losePanel;

    private float coefficientHealth;
    private float coefficientEnergy;
    private float maxHP;
    private float maxEnergy;


    private void Start()
    {
        Time.timeScale = 1;
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
        var rectTransfrom = aim.GetComponent<RectTransform>();
        aim.rectTransform
            .DOScale(1.75f, 0.25f)
            .SetEase(Ease.OutFlash)
            .OnComplete(() => rectTransfrom
            .DOScale(1.0f, 0.25f)
            .SetEase(Ease.Linear));
    }

    private void GetDefaultStates()
    {
        maxHP = GameSettings.Instance.GetMaxPlayerHealth();
        maxEnergy = GameSettings.Instance.GetMaxEnergy();
    }

    public void ActivateHitRedSprite()
    {
        hitRedSprite.DOFade(0.3f, 0.15f).OnComplete(() => hitRedSprite.DOFade(0, 0.35f));
    }

    public void ActivateHitBlueSprite()
    {
        hitBlueSprite.DOFade(0.3f, 0.15f).OnComplete(() => hitBlueSprite.DOFade(0, 0.35f));
    }

    private void EnablePauseMode()
    {
        playModePanel.SetActive(false);
        pauseModePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void EnablePlayMode()
    {
        Time.timeScale = 1;
        pauseModePanel.SetActive(false);
        playModePanel.SetActive(true);
    }

    public void EnableLosePanel()
    {
        pauseModePanel.SetActive(false);
        playModePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void PauseButton()
    {
        EnablePauseMode();
    }

    public void PlayButton()
    {
        EnablePlayMode();
    }

}
