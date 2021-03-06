﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Global : MonoBehaviour
{
    public GameObject ShopPanel;
    public GameObject ProfilePanel;
    public Text AvailableScoreText;
    public Text TotalScoreText;
    public GameObject Player;
    public Sprite[] Sprites;
    public GameObject StartScreen;
    public GameObject SpawnEnemy;
    public GameObject TapButton;


    private bool IsPaused = false;
    private Animator ShopPanelAnimator;
    private Animator ProfilePanelAnimator;

    void Start()
    {
        PlayerData pd = SaveSystem.LoadPlayer();
        ShopPanelAnimator = ShopPanel.GetComponent<Animator>();
        ProfilePanelAnimator = ProfilePanel.GetComponent<Animator>();
        Player.GetComponent<SpriteRenderer>().sprite = Sprites[pd.SelectedFigure.id];
        Player.GetComponent<Renderer>().material.color = new Color(pd.SelectedColor[0] / 255f, pd.SelectedColor[1] / 255f, pd.SelectedColor[2] / 255f);
    }

    public void StartGame()
    {
        TapButton.SetActive(true);
        StartScreen.SetActive(false);
        Player.SetActive(true);
        SpawnEnemy.GetComponent<Spawn>().enabled = true;
    }
    public void RestartGame()
    {
        LoadDataToTexts();
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenShopPanel()
    {
        ShopPanel.SetActive(true);
        ShopPanelAnimator.Play("ShopPanelIn");
    }

    public void OpenProfilePanel()
    {
        ProfilePanel.SetActive(true);
        LoadDataToTexts();
        ProfilePanelAnimator.Play("ProfilePanelIn");
    }

    IEnumerator CloseProfile()
    {
        ProfilePanelAnimator.Play("ProfilePanelOut");
        yield return new WaitForSeconds(1.5f);
        ProfilePanel.SetActive(false);
    }

    public void CloseProfilePanel()
    {
        StartCoroutine(CloseProfile());
    }

    IEnumerator CloseShop()
    {
        ShopPanelAnimator.Play("ShopPanelOut");
        yield return new WaitForSeconds(1.5f);
        ShopPanel.SetActive(false);
    }

    public void CloseShopPanel()
    {
        StartCoroutine(CloseShop());   
    }

    private void LoadDataToTexts()
    {
        PlayerData pd = SaveSystem.LoadPlayer();
        AvailableScoreText.text = "Доступные очки: " + pd.AvailableScore.ToString();
        TotalScoreText.text = "Всего заработано очков: " + pd.TotalScore.ToString();
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
