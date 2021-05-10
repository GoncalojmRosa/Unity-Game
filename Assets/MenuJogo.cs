using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuJogo : MonoBehaviour
{
    [SerializeField]
    GameObject _menuPausa;
    // Start is called before the first frame update
  public void MenuJogo_Recomecar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuPricipal_Iniciar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            _menuPausa.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void MenuJogo_Continuar()
    {
        _menuPausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void MenuPrincipal_Sair()
    {
        Application.Quit();
    }

    public void MenuPrincipal_Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void MenuCreditos_Voltar()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}

