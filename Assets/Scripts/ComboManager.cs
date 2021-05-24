using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    // Cria uma instancia única dessa classe para ser usada em outros scripts(Singleton), usada normalmente em managers
    public static ComboManager instance;

    // Texto que representa o combo que acumula o número de hits na tela
    public Text comboText;

    // Animator do comboText
    private Animator comboTextAnimator;

    // Controla qual é o total do combo atual
    private int totalCombo;

    // Tempo que leva para chamar o método ResetCombo
    private float resetTime = 2f;


    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        comboTextAnimator = comboText.GetComponent<Animator>();

    }

    // Método que é chamado toda vez que um inimigo é atingido
    public void SetCombo()
    {
        totalCombo++;
        comboText.text = "X" + totalCombo;
        comboTextAnimator.SetTrigger("Hit");
        CancelInvoke();
        Invoke("ResetCombo", resetTime);
    }

    // Método chamado quando jogador passa certo tempo sem atacar
    private void ResetCombo()
    {
        totalCombo = 0;
    }

}





