using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] EnemiesSpawner enemiesSpawner;

    [SerializeField] Image aim;
    [SerializeField] Image healthBarFull;
    [SerializeField] Image energyBarFull;

    [SerializeField] Image hitRedSprite;
    [SerializeField] Image hitBlueSprite;

    [SerializeField] GameObject pauseModePanel;
    [SerializeField] GameObject playModePanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject startPanel;

    [SerializeField] Image UltimateImage;
    [SerializeField] TextMeshProUGUI killedEnemyText;
    private float coefficientHealth;
    private float coefficientEnergy;
    private float maxHP;
    private float maxEnergy;
    private float playerReloadTime;
    RectTransform aimRectTransfrom;


    private void Start()
    {
        Time.timeScale = 0;
        GetDefaultStates();
        CalculateHealthBar();
        CalculateEnergyBar();
        aimRectTransfrom = aim.GetComponent<RectTransform>();
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
        aimRectTransfrom
            .DOScale(1.75f, playerReloadTime / 2)
            .SetEase(Ease.OutFlash)
            .OnComplete(() => aimRectTransfrom
            .DOScale(1.0f, playerReloadTime / 2)
            .SetEase(Ease.Linear));
    }

    private void GetDefaultStates()
    {
        maxHP = GameSettings.Instance.GetMaxPlayerHealth();
        maxEnergy = GameSettings.Instance.GetMaxEnergy();
        playerReloadTime = GameSettings.Instance.GetPlayerReloadTime();
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
        playModePanel.SetActive(false);
        losePanel.SetActive(true);
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

    private void HideStartPanel()
    {
        Time.timeScale = 1;
        startPanel.SetActive(false);
        playModePanel.SetActive(true);
    }

    public void StartButton()
    {
        HideStartPanel();
    }

    public void UpdateKilledEnemyText()
    {
        int killedEnemy = enemiesSpawner.GetKilledEnemiesCount();
        killedEnemyText.text = "Defeated Enemy: " + killedEnemy.ToString();
    }

    public void ShowUltimateEffect()
    {
        UltimateImage.DOFade(255, 0.1f)
            .SetEase(Ease.Flash)
            .OnComplete(() => UltimateImage
            .DOFade(0, 0.35f)
            .SetEase(Ease.InFlash));
    }
}
