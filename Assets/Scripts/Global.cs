using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour
{
    public GameObject ShopPanel;
    public GameObject ProfilePanel;

    private bool IsPaused = false;
    private Animator ShopPanelAnimator;
    private Animator ProfilePanelAnimator;
    void Start()
    {
        ShopPanelAnimator = ShopPanel.GetComponent<Animator>();
        ProfilePanelAnimator = ProfilePanel.GetComponent<Animator>();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenShopPanel()
    {
        ShopPanelAnimator.Play("ShopPanelIn");
    }

    public void OpenProfilePanel()
    {
        ProfilePanelAnimator.Play("ProfilePanelIn");
    }

    public void CloseProfilePanel()
    {
        ProfilePanelAnimator.Play("ProfilePanelOut");
    }

    public void CloseShopPanel()
    {
        ShopPanelAnimator.Play("ShopPanelOut");
    }

    public void PauseGame()
    {
        if (IsPaused)
        {
            Time.timeScale = 1;
            IsPaused = !IsPaused;
        }
        else
        {
            Time.timeScale = 0;
            IsPaused = !IsPaused;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
