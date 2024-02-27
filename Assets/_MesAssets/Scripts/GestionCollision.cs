using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    [SerializeField] private Material _materielTouche = default;
    private bool _touche;
    
    private void Start()
    {
        _touche = false;
    }

    /*
     * R�le : saisir la collisation avec un autre objet
     * Entr�e : Pram�tre qui repr�sente l'objet (collider) qui a caus� le contact
     * Sortie : rien
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (!_touche && collision.gameObject.tag == "Player")
        {
            // Change la couleur du mat�riel lors de la la collision
            // GetComponent<MeshRenderer>().material.color = Color.red;

            // Change le mat�tiel lors de la collision
            GetComponent<MeshRenderer>().material = _materielTouche;
            _touche = true;
            GameManager.Instance.AugmenterCollision();
        }
 
    }
}
