using UnityEngine;
using TMPro;

public class ContadorBolas : MonoBehaviour
{
    public TMP_Text textoUI;
    private int bolasEmbocadas = 0;

    public void IncrementarContador()
    {
        bolasEmbocadas++;
        if (textoUI != null)
        {
            textoUI.text = "Bolas embocadas: " + bolasEmbocadas;
        }
    }
}
