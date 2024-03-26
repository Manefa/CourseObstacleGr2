using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] private float _vitesse = 20f;
    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MouvementsJoueur();
    }
    
    private void MouvementsJoueur()
    {
        float positionX = Input.GetAxis("Horizontal");
        float positionZ = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(positionX, 0f, positionZ);
        direction.Normalize();

        // D�placde le joueur(t�l�portation) sur la sc�ne
        //transform.Translate(direction * Time.deltaTime * _vitesse);

        // D�place le rigidbody du joueur en applicant une force
        //_rb.AddForce(direction * Time.fixedDeltaTime * _vitesse);

        //D�place le rigidbody du joueur en utilisatant la vitesse
        _rb.velocity = direction * Time.fixedDeltaTime * _vitesse;
    }

}
