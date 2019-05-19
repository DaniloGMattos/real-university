using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{

    public void Voltar ()
    {
        Debug.Log("Botao Pressionado");
        SceneManager.LoadScene(0);
    }

}
