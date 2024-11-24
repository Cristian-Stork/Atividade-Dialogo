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

    // Variáveis para o sistema de pontuação
    public Text scoreText; // Referência ao texto do Canvas para exibir a pontuação
    private int playerScore = 50; // Pontuação inicial do jogador

    void Start()
    {
        dialogueLines = new string[]
        {
            // Linhas de introdução
            "Olá, pequenino! Seja bem-vindo!", // Linha 0
            "Meu nome é Reginaldo, o fantasma, mas todo mundo me chama de Naldo.", // Linha 1
            "Fico muito feliz que você tenha vindo me visitar! eu não recebo muitas visitas…", // Linha 2
            "Acho que uma cabana abandonada no meio da floresta não é um lugar muito acolhedor…", // Linha 3
            "Mas tá tudo bem, o Naldo aqui se vira muito bem sozinho. Eu gosto de ter o meu espaço. Eu posso fazer o que eu quiser sem ter medo do que os outros vão pensar.", // Linha 4
            "Eu até tenho alguns amigos que me visitam de vez em quando. Tipo o Michael, a tarântula gigante que mora no sótão.", // Linha 5
            "Ou o Fernando, que ele mora mais pra dentro da floresta. Ele gosta de convidar as poucas visitas que eu recebo pra brincarem na toca dele.", // Linha 6
            "Ou a polícia local, eles aparecem toda a vez que alguém passa tempo demais brincando com o Fernando.", // Linha 7
            "Mas eles me ignoram toda a vez, e quase como se eu fosse invisível pra eles.", // Linha 8
            "Só as pessoas do seu tamanho falam comigo e me mostram respeito.", // Linha 9
            "Enfim, posso fazer um tour da casa se você quiser, aonde você quer ir?", // Linha 10

            // Sótão
            "Você quer visitar o Michael? Boa ideia!", // Linha 11
            "Michael! Cadê você?", // Linha 12
            
            // Procurar perto das teias
            "Boa ideia! ele deve estar perto da casa dele.", // Linha 13

            // Procurar perto dos Machados
            "Por quê você acha que o Michael estaria perto da minha coleção de machados super afiados? Isso não faz sentido nenhum. Ah! olha ele ali!", // Linha 14

            "Aqui está o Michael, a tarântula (Reginaldo aponta para o que é obviamente um cachorro morto com pernas animais diferentes costurados em seu corpo).", // Linha 15
            "Ele não é lindo?", // Linha 16

            // Sim é uma tarântula bonita
            "Concordo! Você sabe quantas pernas uma tarântula tem?", // Linha 17

            // Isso daí é uma tarântula?
            "É claro que é! Olha pras pernas dele! você não sabe quantas pernas tem uma tarântula?", // Linha 18

            // Uma tarântula tem oito pernas
            "Isso mesmo! você é bem inteligente.", // Linha 19

            // Uma tarântula tem 10 pernas
            "Não! todo mundo sabe que tarântulas tem 8 pernas! O que é que eles te ensinam na escola?", // Linha 20

            "Bem, acho que já passamos tempo demais aqui. Pra onde você quer ir agora?", //Linha 21

            // Cozinha
            "Ótimo! Vamos para a cozinha!", // Linha 22
            "Chegamos! Essa é a cozinha!", // Linha 23
            "(A cozinha tem um péssimo cheiro, e no balcão tem o que parece ser um cadáver decepado em decomposição)", // Linha 24
            "Eu não quero me gabar, mas eu sou um ótimo cozinheiro. Você quer provar um pouco da minha última obra-prima? (Reginaldo pega um pedaço do cadáver e oferece para você)", // Linha 25

            // Aceitar
            "Isso aí! Espero que tenha gostado", // Linha 26

            // Recusar
            "Nossa! Pra que recusar uma refeição que eu fiz com tanto amor e carinho?", // Linha 27

            "Bem, aqui só tem isso aqui mesmo pra ver. Tem algum outro lugar pra onde você queira ir?", // Linha 28

            // Toca do Fernando
            "Você quer visitar o Fernando? Tudo bem, vamos lá!", // Linha 29
            "Essa é a toca do Fernando. Parece que ele não está aqui hoje. Eu vou ser sincero, sempre achei esse lugar meio feio.", // Linha 30

            // Concordo
            "Olha só! você tem bom gosto também! É impossível de alguém gostar de todos esses ossos no chão.", // Linha 31

            // Discordo
            "Como você pode achar esse lugar legal? Olha pra essa decoração horrível! (Reginaldo aponta para todos os ossos no chão)", // Linha 32

            "Bem, acho que já vimos tudo o que tem pra ver por aqui. Pra onde você quer ir agora?", // Linha 33

            // Quero ir pra casa

            // Jogador venceu
            "Você foi um convidado muito educado, vou deixar você ir pra casa. Obrigado por visitar!", // Linha 34

            // Jogador perdeu
            "Você é muito chato! Foi um péssimo convidado e agora quer ir embora? Eu não vou deixar você sair!", // Linha 35

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
        scoreText.text = "Pontuação: " + playerScore.ToString();
    }

    void ShowOptions()
    {
        dialogueOptions[0].SetActive(true);

        switch (currentLine)
        {
            case 10:
                dialogueOptions[1].SetActive(true);
                dialogueOptions[2].SetActive(true);
                dialogue0.text = "Sotão";
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
                dialogue0.text = "Sim, é uma tarântula bonita";
                dialogue1.text = "Isso daí é uma tarântula?";
                dialogueOptions[1].SetActive(true);
                break;

            case 17:
                dialogue0.text = "Uma tarântula tem oito pernas";
                dialogue1.text = "Uma tarântula tem 10 pernas";
                break;

            case 18:
                dialogue0.text = "Uma tarântula tem oito pernas";
                dialogue1.text = "Uma tarântula tem 10 pernas";
                break;

            case 21:
                dialogueOptions[0].SetActive(false);
                dialogueOptions[1].SetActive(false);
                dialogueOptions[2].SetActive(false);

                if (!visitouSotao)
                {
                    dialogueOptions[0].SetActive(true);
                    dialogue0.text = "Sotão";
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
                    dialogue0.text = "Sotão";
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
                    dialogue0.text = "Sotão";
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
            dialogueText.text = "Você venceu!";
        }
        else
        {
            dialogueText.text = "Você perdeu :(";
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
