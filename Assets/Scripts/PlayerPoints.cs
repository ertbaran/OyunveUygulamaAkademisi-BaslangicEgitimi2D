using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
    public int point = 0;
    AudioSource _audio;
    [SerializeField] TextMeshProUGUI _textMesh;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _textMesh.text = Score.totalScore.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Diamond"))
        {
            _audio.Play();
            Destroy(collision.gameObject);
            point++;
            Score.totalScore = point;
            _textMesh.text = Score.totalScore.ToString();
        }
    }
}
