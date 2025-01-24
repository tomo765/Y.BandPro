using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ttext = TMPro.TextMeshPro;

public class GenreUI : MonoBehaviour
{
    [SerializeField] private Ttext m_GenreText;

    public string GetGenreText()=> m_GenreText.text;
    public void SetGenreText(string text) => m_GenreText.text = text;
    public void SetActive(bool b) => gameObject.SetActive(b);
}
