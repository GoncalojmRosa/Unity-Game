using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int totalOvos;
    [SerializeField]
    int NrOvosDoNivel;
    [SerializeField]
    int OvosApanhadosNesteNivel;
    [SerializeField]
    Text DadosJogo;
    [SerializeField]
    GameObject MenuDerrota;

    GameObject player;


    // Start is called before the first frame update
    void Awake()
    {
        GameManager[] ops = GameObject.FindObjectsOfType<GameManager>();
        if (ops.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    // Update is called once per frame
    void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Time.timeScale = 1;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            return;
        }
        NrOvosDoNivel = FindObjectsOfType<Apanhar>().Length;

        if (DadosJogo == null)
        {
            DadosJogo = GameObject.FindGameObjectWithTag("TxtOvos").GetComponent<Text>();
        }

        AtualizarDadosJogador();

        if (MenuDerrota == null)
        {
            MenuDerrota = GameObject.FindGameObjectWithTag("MenuDerrota");
        }

        if (MenuDerrota != null)
        {
            MenuDerrota.SetActive(false);
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void AtualizarDadosJogador()
    {
        if (DadosJogo != null)
            DadosJogo.text = "Moedas no nível: " + NrOvosDoNivel + " | Total de Moedas: " + totalOvos;
    }
    public void adicionaOvo()
    {
        Debug.Log("Apanhei uma moeda");
        totalOvos++;
        OvosApanhadosNesteNivel++;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            return;
        if (player == null)
        {
            MenuDerrota.SetActive(true);
            Time.timeScale = 0;
        }

        if (NrOvosDoNivel == OvosApanhadosNesteNivel)
        {
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else
                SceneManager.LoadScene("MenuPrincipal");
        }
    }
}
