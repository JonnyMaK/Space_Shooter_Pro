using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    private string _ScoreUIText;
    public int score = 0;
    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private Text _gameover;
    [SerializeField]
    private Text _restartText;
    [SerializeField]
    private GameManager _gameManager;


    // Start is called before the first frame update
    void Start()
    {
       // _livesSprites[Lives] 
        _ScoreUIText = _scoreText.text;
        _scoreText.text = _ScoreUIText + score;
        _gameover.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.Log("No Game Manager object found");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScoreUpdate(int playerscore)
    {
        score = score + playerscore;
        _scoreText.text = _ScoreUIText + score;
    }

    public void LivesUpdate(int currentLives)
    {
        _livesImg.sprite = _livesSprites[currentLives];

        if (currentLives == 0)
        {
            _gameover.gameObject.SetActive(true);
            _restartText.gameObject.SetActive(true);
            _gameManager.GameOver();

        }
    }

 
    
}
