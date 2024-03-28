using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManagerGame : MonoBehaviour
{
    public static UIManagerGame Instance;

    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private TMP_Text _txtCollisions = default;
    [SerializeField] private GameObject _panneauPause = default;

    private bool _enPause = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _txtCollisions.text  = "Collisions : " + GameManager.Instance.Collisions;
    }

    void Update()
    {
        float temps = Time.time - GameManager.Instance.TempsDepart;
        _txtTemps.text = "Temps : " + temps.ToString("f2");

        GestionPause();
    }

    private void GestionPause()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !_enPause) {
            _panneauPause.SetActive(true);
            Time.timeScale = 0;
            _enPause = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && _enPause)
        {
            _panneauPause.SetActive(false);
            Time.timeScale = 1;
            _enPause = false;
        }
    }

    public void ChangerCollisions(int p_pointage)
    {
        _txtCollisions.text = "Collisions : " + p_pointage.ToString();
    }

    public void Quitter()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Redemarrer()
    {
        SceneManager.LoadScene(0);
    }

    public void reprendre()
    {
        _panneauPause.SetActive(false);
        Time.timeScale = 1;
        _enPause = false;
        EventSystem.current.SetSelectedGameObject(null);
    }
}
