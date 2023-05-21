using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private CameraController cameraController;

    public void PlayerShoot()
    {
        player.Shoot();
    }

    public void UseUltimatePower()
    {
        player.UseUltimate();
    }

    public void VisualHit()
    {
        cameraController.ShakeCamera();
        if (Application.platform == RuntimePlatform.Android)
        {
            Handheld.Vibrate();
        }
    }

    public void RestartSceneButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
