using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator animPlayer;
    [SerializeField] private Animator animChest;
    [SerializeField] private MovementPlayer move;
    private bool estaNoChao = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animPlayer = GetComponent<Animator>();
        move = GetComponent<MovementPlayer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Andando para frente
        if (Input.GetKey(KeyCode.W))
        {
            animPlayer.SetBool("Andar", true);
            move.Andar();
        }
        else
        {
            animPlayer.SetBool("Andar", false);
        }

        //Andando para trás
        if (Input.GetKey(KeyCode.S))
        {
            animPlayer.SetBool("AndarTras", true);
            move.Andar();
        }
        else
        {
            animPlayer.SetBool("AndarTras", false);
        }

        //Correndo
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            animPlayer.SetBool("Correr", true);
        }
        else
        {
            animPlayer.SetBool("Correr", false);
        }

        //Torcida
        if(Input.GetKey(KeyCode.Q))
        {
            animPlayer.SetTrigger("Torcida");
        }

        //Interagindo
        if (Input.GetKey(KeyCode.E))
        {
            animPlayer.SetTrigger("Interact");
        }

        //Pegando
        if (Input.GetKey(KeyCode.F))
        {
            animPlayer.SetTrigger("Pegar");
        }

        //Atacando
        if (Input.GetMouseButtonDown(0))
        {
            animPlayer.SetTrigger("Ataque");
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            move.Virar();
            animPlayer.SetBool("Andar", true);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            animPlayer.SetTrigger("Pular");
            move.Pular();
            estaNoChao = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Chao"))
        {
            animPlayer.SetBool("NoChao", true);
            estaNoChao = true;
        }
        /*
        else
        {
            animPlayer.SetBool("NoChao", false);
        }
        */
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            animPlayer.SetBool("NoChao", false);
            estaNoChao = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chest"))
        {
            animChest.SetBool("Open", true);
        }
    }
}
