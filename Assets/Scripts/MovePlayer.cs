using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float velocidade = 5.0f;
    [SerializeField] float forcaPulo = 5.0f;
    Vector3 anguloRotacao = new Vector3(0, 90, 0);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Andar()
    { 
        float moveV = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, 0, moveV * velocidade * Time.deltaTime);

    }

    public void Pular()
    {
        rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
    }

    public void Virar()
    {
        float moveH = Input.GetAxis("Horizontal");
        Quaternion rotacao = Quaternion.Euler(anguloRotacao * moveH * Time.deltaTime);
        rb.MoveRotation(rotacao * rb.rotation);

    }

}
