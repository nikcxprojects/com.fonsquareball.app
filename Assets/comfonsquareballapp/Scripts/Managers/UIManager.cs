using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance 
    { 
        get => FindObjectOfType<UIManager>(); 
    }

    private const float scoreRate = 0.65f;
    private float nextTime;

    int score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Text finalScore;

    [Space(10)]
    [SerializeField] Transform circleTarget;
    [SerializeField] Transform grid;

    private GameObject _gameRef;

    [Space(10)]
    [SerializeField] GameObject menu;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject avatar;
    [SerializeField] GameObject game;
    [SerializeField] GameObject result;


    private void Start()
    {
        OpenMenu();
        SetBall(BallManager.BallId);
    }

    private void Update()
    {
        if(result.activeSelf)
        {
            return;
        }

        if(Time.time > nextTime)
        {
            score += 1;
            nextTime = Time.time + scoreRate;

            scoreText.text = $"{score}";
            finalScore.text = scoreText.text;
        }
    }

    public void StartGame()
    {
        score = 0;
        nextTime = 0.0f;

        scoreText.text = $"{score}";

        var _parent = GameObject.Find("Environment").transform;
        var _prefab = Resources.Load<GameObject>("level");

        _gameRef = Instantiate(_prefab, _parent);

        menu.SetActive(false);

        game.SetActive(true);
        result.SetActive(false);
    }

    public void SetBall(int id)
    {
        BallManager.BallId = id;
        circleTarget.position = grid.GetChild(id - 1).position;
    }

    public void OpenSettings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void OpenAvatar()
    {
        menu.SetActive(false);
        avatar.SetActive(true);
    }

    public void OpenMenu()
    {
        if (_gameRef)
        {
            Destroy(_gameRef);
        }

        game.SetActive(false);
        settings.SetActive(false);
        avatar.SetActive(false);
        result.SetActive(false);

        menu.SetActive(true);
    }

    public void GameOver()
    {
        if (_gameRef)
        {
            Destroy(_gameRef);
        }

        result.SetActive(true);
    }
}
