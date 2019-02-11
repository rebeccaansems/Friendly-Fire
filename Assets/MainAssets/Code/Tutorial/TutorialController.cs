using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public int currentTutorialStep;

    public CanvasGroup commanderPanel, responsePanel;

    public TextMeshProUGUI[] responsesText;
    public TextMeshProUGUI commanderText;

    public GameObject fingerCircle, fingerTapping, enemy;

    private int currentCommander, currentResponse, responseChoice;

    private int rotationTutorialOn, tappingTutorialOn, enemyTutorialOn;

    private void Start()
    {
        currentTutorialStep = 0;
        currentCommander = 0;
        currentResponse = 0;

        rotationTutorialOn = 0;
        tappingTutorialOn = 0;
        enemyTutorialOn = 0;
    }

    public void NextStep(int choice)
    {
        responseChoice = choice;
        currentTutorialStep++;
    }

    public void Update()
    {
        commanderText.text = commanderResponseTexts[currentCommander][responseChoice] + "" + commanderTexts[currentCommander];
        for (int i = 0; i < responsesText.Length; i++)
        {
            responsesText[i].text = responseTexts[currentResponse][i];
        }

        switch (currentTutorialStep)
        {
            case 0:
                currentCommander = 0;
                currentResponse = 0;

                Time.timeScale = 0;
                break;
            case 1:
                currentCommander = 1;
                currentResponse = 1;

                Time.timeScale = 0;
                break;
            case 2:
                currentCommander = 2;
                currentResponse = 2;

                Time.timeScale = 0;
                break;
            case 3:
                currentCommander = 3;

                Hide(responsePanel);

                if (rotationTutorialOn == 0)
                {
                    Time.timeScale = 1;

                    ShowCircle();
                    rotationTutorialOn++;
                }
                break;
            case 4:
                currentCommander = 4;
                currentResponse = 3;

                if (tappingTutorialOn == 0)
                {
                    ShowTapping();
                    tappingTutorialOn++;
                }
                break;
            case 5:
                currentCommander = 5;

                Show(responsePanel);
                Time.timeScale = 0;
                break;
            case 6:
                currentCommander = 6;

                Hide(responsePanel);

                if (enemyTutorialOn == 0)
                {
                    enemyTutorialOn++;
                    ShowEnemy();
                }
                Time.timeScale = 1;
                break;
            case 7:
                currentCommander = 7;
                currentResponse = 4;

                Show(responsePanel);
                Time.timeScale = 0;
                break;
            case 8:
                currentCommander = 8;
                currentResponse = 5;

                Time.timeScale = 0;
                break;
            case 9:
                currentCommander = 9;
                currentResponse = 6;

                Time.timeScale = 0;
                break;
            case 10:
                Hide(commanderPanel);
                Hide(responsePanel);

                UIGameoverController.instance.GameOver(true);
                PlayerPrefs.SetInt("TutorialCompleted", 1);
                break;
        }

        if (rotationTutorialOn == 1)
        {
            CountRotation();
            if (nrOfRotations > 0)
            {
                StartCoroutine(UpdateTutorialStep(0.25f));
                rotationTutorialOn++;
                HideCircle();
            }
        }

        if (tappingTutorialOn == 1)
        {
            if (GameController.instance.shotsFired > 0)
            {
                StartCoroutine(UpdateTutorialStep(1.5f));
                tappingTutorialOn++;
                HideTapping();
            }
        }

        if (enemyTutorialOn == 1)
        {
            if (enemy == null)
            {
                currentTutorialStep++;
                enemyTutorialOn++;
            }
        }
    }

    private void Hide(CanvasGroup panel)
    {
        panel.alpha = 0;
        panel.blocksRaycasts = false;
        panel.interactable = false;
    }

    private void Show(CanvasGroup panel)
    {
        panel.alpha = 1;
        panel.blocksRaycasts = true;
        panel.interactable = true;
    }

    #region enemy

    void ShowEnemy()
    {
        if (enemy != null)
        {
            if (enemy.GetComponent<SpriteRenderer>().enabled == false)
            {
                GameController.instance.player.transform.position += new Vector3(1, 0.5f, 0);
            }
            enemy.GetComponent<SpriteRenderer>().enabled = true;
            enemy.GetComponent<Collider2D>().enabled = true;
        }
    }

    public void Next()
    {
        SceneManager.LoadScene(0);
    }

    #endregion

    #region shooting tutorial

    private void ShowTapping()
    {
        fingerTapping.SetActive(true);
        fingerTapping.GetComponent<Animator>().SetBool("isTap", true);
    }

    private void HideTapping()
    {
        fingerTapping.SetActive(false);
    }

    #endregion

    #region rotating tutorial
    private float totalRotation = 0;
    public int nrOfRotations
    {
        get
        {
            return Mathf.Abs(((int)totalRotation) / 360);
        }
    }

    private Vector3 lastPoint;

    private void ShowCircle()
    {
        fingerCircle.SetActive(true);
        fingerCircle.GetComponent<Animator>().SetBool("isCircle", true);
    }

    private void HideCircle()
    {
        fingerCircle.SetActive(false);
    }

    private void CountRotation()
    {
        Vector3 facing = GameController.instance.player.transform.TransformDirection(Vector3.up);
        facing.z = 0;

        float angle = Vector3.Angle(lastPoint, facing);
        if (Vector3.Cross(lastPoint, facing).z < 0)
            angle *= -1;

        totalRotation += angle;
        lastPoint = facing;
    }
    #endregion

    #region Text

    private string[] commanderTexts = new string[]
    {
        "Captain Webb? Captain Webb? Please acknowledge if you're receiving this.",
        "ll of the other hive ships have been abandoned! Are you ok?",
        "I'm getting some diagnostics that say your flight movement system is down, is everything else fine?",
        "we'll run a quick diagnostic. Uhm, first, can you still rotate fine?",
        "Perfect, can you still shoot?",
        "Great. I'm getting a lot of local static can you see any other ships?",
        "I'm getting no life scans. It's an empty ship, can you dispose of it?",
        "Did you see that? They left their hive commands enabled!",
        "That means that whenever you move, they move, when you shoot, they shoot. You get the picture.",
        "We're going to port you over to some locations, please dispose of any ships you see. Be safe."
    };

    private List<string[]> commanderResponseTexts = new List<string[]>
    {
        new string[]
        {
            "",
            "",
            ""
        },

        new string[]
        {
            "Oh thank god. A",
            "Commander Scott. A",
            "Uh, ok, Captain Webb a"
        },

        new string[]
        {
            "Wonderful! ",
            "The definition of the word Captain. ",
            "Are you sure you're ok? "
        },

        new string[]
        {
            "Ok ",
            "You can't fly, ",
            "No? Uhm, "
        },

        new string[]
        {
            "",
            "",
            ""
        },

        new string[]
        {
            "",
            "",
            ""
        },

        new string[]
        {
            "",
            "No, ",
            "That's not an answer. I see the ship and "
        },

        new string[]
        {
            "",
            "",
            ""
        },

        new string[]
        {
            "",
            "",
            "Not cool. "
        },

        new string[]
        {
            "",
            "It's not. ",
            ""
        }
    };

    private List<string[]> responseTexts = new List<string[]>
    {
        new string[]
        {
            "Acknowledged, Captain Webb here.",
            "Who is this?",
            "Yeah, what up?"
        },

        new string[]
        {
            "I'm ok, I think.",
            "What do you mean abandoned?",
            "Everything is chilli dog time."
        },

        new string[]
        {
            "I don't know? Maybe?",
            "What do you mean my movement system is down!",
            "The fridge works, does that count?"
        },

        new string[]
        {
            "Affirmative.",
            "Yes, are they hostile?",
            "Probably."
        },

        new string[]
        {
            "How will that affect me?",
            "What does that mean?",
            "Cool?"
        },

        new string[]
        {
            "Noted.",
            "That doesn't sound good.",
            "Less cool."
        },

        new string[]
        {
            "Mission accepted.",
            "Wait, where am I going?",
            "Peace."
        }
    };

    #endregion

    IEnumerator UpdateTutorialStep(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        currentTutorialStep++;
    }

}
