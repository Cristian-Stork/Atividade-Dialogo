using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text dialogueText;
    public Text dialogue0;
    public Text dialogue1;
    public Text dialogue2;
    public Text dialogue3;
    public GameObject[] dialogueOptions;
    public string[] dialogueLines;
    public int currentLine = 0;

    public GameObject cabana;
    public GameObject sotao;
    public GameObject caverna;
    public GameObject cozinha;

    private bool visitouSotao;
    private bool visitouCozinha;
    private bool visitouToca;

    // Vari�veis para o sistema de pontua��o
    public Text scoreText; // Refer�ncia ao texto do Canvas para exibir a pontua��o
    private int playerScore = 50; // Pontua��o inicial do jogador

    void Start()
    {
        dialogueLines = new string[]
        {
            // Linhas de introdu��o
            "Ol�, pequenino! Seja bem-vindo!", // Linha 0
            "Meu nome � Reginaldo, o fantasma, mas todo mundo me chama de Naldo.", // Linha 1
            "Fico muito feliz que voc� tenha vindo me visitar! eu n�o recebo muitas visitas�", // Linha 2
            "Acho que uma cabana abandonada no meio da floresta n�o � um lugar muito acolhedor�", // Linha 3
            "Mas t� tudo bem, o Naldo aqui se vira muito bem sozinho. Eu gosto de ter o meu espa�o. Eu posso fazer o que eu quiser sem ter medo do que os outros v�o pensar.", // Linha 4
            "Eu at� tenho alguns amigos que me visitam de vez em quando. Tipo o Michael, a tar�ntula gigante que mora no s�t�o.", // Linha 5
            "Ou o Fernando, que ele mora mais pra dentro da floresta. Ele gosta de convidar as poucas visitas que eu recebo pra brincarem na toca dele.", // Linha 6
            "Ou a pol�cia local, eles aparecem toda a vez que algu�m passa tempo demais brincando com o Fernando.", // Linha 7
            "Mas eles me ignoram toda a vez, e quase como se eu fosse invis�vel pra eles.", // Linha 8
            "S� as pessoas do seu tamanho falam comigo e me mostram respeito.", // Linha 9
            "Enfim, posso fazer um tour da casa se voc� quiser, aonde voc� quer ir?", // Linha 10

            // S�t�o
            "Voc� quer visitar o Michael? Boa ideia!", // Linha 11
            "Michael! Cad� voc�?", // Linha 12
            
            // Procurar perto das teias
            "Boa ideia! ele deve estar perto da casa dele.", // Linha 13

            // Procurar perto dos Machados
            "Por qu� voc� acha que o Michael estaria perto da minha cole��o de machados super afiados? Isso n�o faz sentido nenhum. Ah! olha ele ali!", // Linha 14

            "Aqui est� o Michael, a tar�ntula (Reginaldo aponta para o que � obviamente um cachorro morto com pernas animais diferentes costurados em seu corpo).", // Linha 15
            "Ele n�o � lindo?", // Linha 16

            // Sim � uma tar�ntula bonita
            "Concordo! Voc� sabe quantas pernas uma tar�ntula tem?", // Linha 17

            // Isso da� � uma tar�ntula?
            "� claro que �! Olha pras pernas dele! voc� n�o sabe quantas pernas tem uma tar�ntula?", // Linha 18

            // Uma tar�ntula tem oito pernas
            "Isso mesmo! voc� � bem inteligente.", // Linha 19

            // Uma tar�ntula tem 10 pernas
            "N�o! todo mundo sabe que tar�ntulas tem 8 pernas! O que � que eles te ensinam na escola?", // Linha 20

            "Bem, acho que j� passamos tempo demais aqui. Pra onde voc� quer ir agora?", //Linha 21

            // Cozinha
            "�timo! Vamos para a cozinha!", // Linha 22
            "Chegamos! Essa � a cozinha!", // Linha 23
            "(A cozinha tem um p�ssimo cheiro, e no balc�o tem o que parece ser um cad�ver decepado em decomposi��o)", // Linha 24
            "Eu n�o quero me gabar, mas eu sou um �timo cozinheiro. Voc� quer provar um pouco da minha �ltima obra-prima? (Reginaldo pega um peda�o do cad�ver e oferece para voc�)", // Linha 25

            // Aceitar
            "Isso a�! Espero que tenha gostado", // Linha 26

            // Recusar
            "Nossa! Pra que recusar uma refei��o que eu fiz com tanto amor e carinho?", // Linha 27

            "Bem, aqui s� tem isso aqui mesmo pra ver. Tem algum outro lugar pra onde voc� queira ir?", // Linha 28

            // Toca do Fernando
            "Voc� quer visitar o Fernando? Tudo bem, vamos l�!", // Linha 29
            "Essa � a toca do Fernando. Parece que ele n�o est� aqui hoje. Eu vou ser sincero, sempre achei esse lugar meio feio.", // Linha 30

            // Concordo
            "Olha s�! voc� tem bom gosto tamb�m! � imposs�vel de algu�m gostar de todos esses ossos no ch�o.", // Linha 31

            // Discordo
            "Como voc� pode achar esse lugar legal? Olha pra essa decora��o horr�vel! (Reginaldo aponta para todos os ossos no ch�o)", // Linha 32

            "Bem, acho que j� vimos tudo o que tem pra ver por aqui. Pra onde voc� quer ir agora?", // Linha 33

            // Quero ir pra casa

            // Jogador venceu
            "Voc� foi um convidado muito educado, vou deixar voc� ir pra casa. Obrigado por visitar!", // Linha 34

            // Jogador perdeu
            "Voc� � muito chato! Foi um p�ssimo convidado e agora quer ir embora? Eu n�o vou deixar voc� sair!", // Linha 35

        };

        ShowDialogueLine();
        dialogueOptions[1].SetActive(false);
        dialogueOptions[2].SetActive(false);
        dialogueOptions[3].SetActive(false);
        UpdateScoreText();
    }

    void ShowDialogueLine()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
            ShowOptions();
        }
        else
        {
            EndDialogue();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Pontua��o: " + playerScore.ToString();
    }

    void ShowOptions()
    {
        dialogueOptions[0].SetActive(true);

        switch (currentLine)
        {
            case 10:
                dialogueOptions[1].SetActive(true);
                dialogueOptions[2].SetActive(true);
                dialogue0.text = "Sot�o";
                dialogue1.text = "Cozinha";
                dialogue2.text = "Toca do Fernando";
                break;

            case 11:
                dialogueOptions[1].SetActive(false);
                dialogueOptions[2].SetActive(false);
                dialogue0.text = "Continuar";
                visitouSotao = true;
                break;

            case 12:
                sotao.SetActive(true);
                cabana.SetActive(false);
                caverna.SetActive(false);
                cozinha.SetActive(false);
                dialogue0.text = "Procurar perto das teias";
                dialogue1.text = "Procurar perto dos Machados";
                dialogueOptions[1].SetActive(true);
                break;

            case 16:
                dialogue0.text = "Sim, � uma tar�ntula bonita";
                dialogue1.text = "Isso da� � uma tar�ntula?";
                dialogueOptions[1].SetActive(true);
                break;

            case 17:
                dialogue0.text = "Uma tar�ntula tem oito pernas";
                dialogue1.text = "Uma tar�ntula tem 10 pernas";
                break;

            case 18:
                dialogue0.text = "Uma tar�ntula tem oito pernas";
                dialogue1.text = "Uma tar�ntula tem 10 pernas";
                break;

            case 21:
                dialogueOptions[0].SetActive(false);
                dialogueOptions[1].SetActive(false);
                dialogueOptions[2].SetActive(false);

                if (!visitouSotao)
                {
                    dialogueOptions[0].SetActive(true);
                    dialogue0.text = "Sot�o";
                }

                if (!visitouCozinha)
                {
                    dialogueOptions[1].SetActive(true);
                    dialogue1.text = "Cozinha";
                }

                if (!visitouToca)
                {
                    dialogueOptions[2].SetActive(true);
                    dialogue2.text = "Toca";
                }

                if (visitouSotao && visitouCozinha && visitouToca)
                {
                    dialogueOptions[3].SetActive(true);
                    dialogue3.text = "Quero ir pra casa";
                }
                break;

            case 22:
                dialogueOptions[1].SetActive(false);
                dialogueOptions[2].SetActive(false);
                dialogue0.text = "Continuar";
                visitouCozinha = true;
                break;

            case 23:
                cozinha.SetActive(true);
                cabana.SetActive(false);
                caverna.SetActive(false);
                sotao.SetActive(false);
                break;

            case 25:
                dialogue0.text = "Aceitar";
                dialogue1.text = "Rejeitar";
                dialogueOptions[1].SetActive(true);
                break;

            case 28:
                dialogueOptions[0].SetActive(false);
                dialogueOptions[1].SetActive(false);
                dialogueOptions[2].SetActive(false);

                if (!visitouSotao)
                {
                    dialogueOptions[0].SetActive(true);
                    dialogue0.text = "Sot�o";
                }

                if (!visitouCozinha)
                {
                    dialogueOptions[1].SetActive(true);
                    dialogue1.text = "Cozinha";
                }

                if (!visitouToca)
                {
                    dialogueOptions[2].SetActive(true);
                    dialogue2.text = "Toca";
                }

                if (visitouSotao && visitouCozinha && visitouToca)
                {
                    dialogueOptions[3].SetActive(true);
                    dialogue3.text = "Quero ir pra casa";
                }
                break;

            case 29:
                dialogueOptions[1].SetActive(false);
                dialogueOptions[2].SetActive(false);
                dialogue0.text = "Continuar";
                visitouToca = true;
                break;

            case 30:
                caverna.SetActive(true);
                cabana.SetActive(false);
                sotao.SetActive(false);
                cozinha.SetActive(false);
                dialogue0.text = "Concordo";
                dialogue1.text = "Discordo";
                dialogueOptions[1].SetActive(true);
                break;

            case 33:
                dialogueOptions[0].SetActive(false);
                dialogueOptions[1].SetActive(false);
                dialogueOptions[2].SetActive(false);

                if (!visitouSotao)
                {
                    dialogueOptions[0].SetActive(true);
                    dialogue0.text = "Sot�o";
                }

                if (!visitouCozinha)
                {
                    dialogueOptions[1].SetActive(true);
                    dialogue1.text = "Cozinha";
                }

                if (!visitouToca)
                {
                    dialogueOptions[2].SetActive(true);
                    dialogue2.text = "Toca";
                }

                if (visitouSotao && visitouCozinha && visitouToca)
                {
                    dialogueOptions[3].SetActive(true);
                    dialogue3.text = "Quero ir pra casa";
                }
                break;

            default:
                dialogueOptions[0].SetActive(true);
                dialogueOptions[1].SetActive(false);
                dialogueOptions[2].SetActive(false);
                dialogue0.text = "Continuar";
                break;
        }
    }

    void EndDialogue()
    {
        if (playerScore >= 100)
        {
            dialogueText.text = "Voc� venceu!";
        }
        else
        {
            dialogueText.text = "Voc� perdeu :(";
        }

        foreach (GameObject option in dialogueOptions)
        {
            option.SetActive(false);
        }
    }

    public void SelectOption(int optionIndex)
    {
        switch (optionIndex)
        {
            case 0:
                HandleYesOption();
                break;
            case 1:
                HandleNoOption();
                break;
            case 2:
                Toca();
                break;
            case 3:
                QueroIrPraCasa();
                break;
        }

        ShowDialogueLine();
    }

    void HandleYesOption()
    {
        switch (currentLine)
        {
            case 10:
                currentLine++;
                break;
            case 12:
                playerScore += 10;
                UpdateScoreText();
                currentLine++;
                break;
            case 13:
                currentLine = 15;
                break;
            case 16:
                playerScore += 10;
                UpdateScoreText();
                currentLine++;
                break;
            case 17:
                playerScore += 10;
                UpdateScoreText();
                currentLine = 19;
                break;
            case 19:
                currentLine = 21;
                break;
            case 25:
                playerScore += 10;
                UpdateScoreText();
                currentLine++;
                break;
            case 26:
                currentLine = 28;
                break;
            case 28:
                currentLine = 11;
                break;
            case 30:
                playerScore += 10;
                UpdateScoreText();
                currentLine++;
                break;
            case 31:
                currentLine = 33;
                break;
            case 33:
                currentLine = 11;
                break;
            case 34:
                currentLine += 10;
                break;
            default:
                currentLine++;
                break;
        }
    }

    void HandleNoOption()
    {
        switch (currentLine)
        {
            case 10:
                currentLine = 22;
                break;
            case 12:
                playerScore -= 10;
                UpdateScoreText();
                currentLine = 14;
                break;
            case 16:
                playerScore -= 10;
                UpdateScoreText();
                currentLine = 18;
                break;
            case 18:
                playerScore -= 10;
                UpdateScoreText();
                currentLine = 20;
                break;
            case 21:
                currentLine = 22;
                break;
            case 25:
                playerScore -= 10;
                UpdateScoreText();
                currentLine = 27;
                break;
            case 27:
                playerScore -= 10;
                UpdateScoreText();
                currentLine++;
                break;
            case 30:
                playerScore -= 10;
                UpdateScoreText();
                currentLine = 32;
                break;
            case 33:
                currentLine = 22;
                break;
            default:
                currentLine++;
                break;
        }
    }

    void Toca()
    {
        switch (currentLine)
        {
            case 10:
                currentLine = 29;
                break;
            case 21:
                currentLine = 29;
                break;
            case 28:
                currentLine = 29;
                break;
        }
    }

    void QueroIrPraCasa()
    {
        switch (currentLine)
        {
            default:
                dialogueOptions[3].SetActive(false);

                if (playerScore >= 100)
                    currentLine = 34;

                else
                    currentLine = 35;
                break;
        }
    }
}
