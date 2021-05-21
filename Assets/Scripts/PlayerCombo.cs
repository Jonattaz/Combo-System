using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombo : MonoBehaviour
{
    // Referência a classe Combo
    public Combo[] combos;

    // Verifica em qual hit se encontra o combo, primeiro, segundo ou terceiro
    public List<string> currentCombo;

    // Hit atual e próximo hit
    private Hit currentHit, nextHit;

    // Cronometro
    private float comboTimer;

    // Referência o animator associado ao player/Objeto
    private Animator anim;

    // Controla o inicio do combo, para que possa ir para o próximo hit
    private bool startCombo;

    // Controla se o jogador pode apertar o botão de hit ou não 
    private bool canHit = true;

    // Controla o reset do combo
    private bool resetCombo;


    // Start is called before the first frame update
    void Start()
    {
        // Referência o objeto
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Chama o método a cada frame do jogo
        CheckInputs();

    }

    // Método responsável por checar os inputs
    // Dois momentos, combo não foi iniciado e combo iniciado
    void CheckInputs()
    {
        // Combo não foi iniciado, checando inputs
        for (int i = 0; i < combos.Length; i++)
        {

            // Evita que o jogador aperte o botaão fora do tempo(esmagar os controles) ---- OPCIONAL
            // Verificar todos os botões usados em combos
            if ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && !canHit)
            {

                resetCombo = true;
            }

            // Verifica se o combo do loop atual possui mais hits que a lista currentCombo
            if (combos[i].hits.Length > currentCombo.Count)
            {

                // Verifica se o jogador apertou o botão correspondente a algum primeiro hit dos combos possíveis
                if (Input.GetButtonDown(combos[i].hits[currentCombo.Count].inputButton))
                {
                    // Verifica se é o primeiro hit de algum combo
                    if (currentCombo.Count == 0)
                    {
                        Debug.Log("Primeiro hit foi adicionado");
                        PlayHit(combos[i].hits[currentCombo.Count]);
                        break;
                    }
                    else
                    {
                        // Controla se a combinação de combo está igual ou não, se o botão pressionado é o correto ou não
                        bool comboMatch = false;
                        for (int j = 0; j < currentCombo.Count; j++)
                        {
                            if (currentCombo[j] != combos[i].hits[j].inputButton)
                            {
                                Debug.Log("Input não pertence ao combo atual");
                                comboMatch = false;
                                break;
                            }
                            else
                            {
                                comboMatch = true;
                            }
                        }

                        if (comboMatch && canHit)
                        {
                            Debug.Log("Hit adicionado ao combo");
                            nextHit = combos[i].hits[currentCombo.Count];
                            canHit = false;
                            break;
                        }
                    }
                }

            }
        }


        // Controla as animações de ataque
        if (startCombo)
        {
            comboTimer += Time.deltaTime;

            // Ativa o próximo hit quando o tempo da animação atual for menor que o cronometro
            if (comboTimer >= currentHit.animationTime && !canHit)
            {
                PlayHit(nextHit);
                if (resetCombo)
                {
                    canHit = false;
                    CancelInvoke();
                    Invoke("ResetCombo", currentHit.animationTime);
                }
            }

            // Reseta o combo
            if (comboTimer >= currentHit.resetTime)
            {
                ResetCombo();
            }


        }


    }

    // Método responsável pelos ataques usados
    void PlayHit(Hit hit)
    {
        comboTimer = 0;
        // Ativa a animação de acordo com o nome
        anim.Play(hit.animation);
        startCombo = true;
        currentCombo.Add(hit.inputButton);
        currentHit = hit;
        canHit = true;
    }

    // Método responsável pelo reset do combo,
    // ao passar o tempo que foi colocado no reset time ou uma tecla seja pressionada de maneira errada,
    // o combo é resetado
    void ResetCombo()
    {
        startCombo = false;
        comboTimer = 0;
        currentCombo.Clear();
        anim.Rebind();
        canHit = true;
    }


}
