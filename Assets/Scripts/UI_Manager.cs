using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private TMP_Text _gameOverText;
    [SerializeField]
    private TMP_Text _restartText;
    [SerializeField]
    private Image _LivesImg;
    [SerializeField]
    private Sprite[] _livesSprites;

    private GameManager _gameManager;



    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.LogError("Game Manager is NULL");
        }
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        _LivesImg.sprite = _livesSprites[currentLives];
    }

    public void GameOver()
    {
        _gameManager.GameOver();
        StartCoroutine(FlickerRoutine());
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
    }

    IEnumerator FlickerRoutine()
    {
        while(true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);

            _gameOverText.text = " ";
            yield return new WaitForSeconds(0.5f);
        }

    }



}
