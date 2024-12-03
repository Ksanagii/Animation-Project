using Unity.VisualScripting;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator animPlayer;
    [SerializeField] private Animator animChest;
    [SerializeField] private MovementPlayer move;
    private bool estaNoChao = true;
    static public bool morto;
    public int keys;
    bool podePegar = false;
    bool pegando = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animPlayer = GetComponent<Animator>();
        move = GetComponent<MovementPlayer>();
        morto = false;
        keys = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!morto)
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
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                animPlayer.SetBool("Correr", true);
            }
            else
            {
                animPlayer.SetBool("Correr", false);
            }

            //Torcida
            if (Input.GetKey(KeyCode.Q))
            {
                animPlayer.SetTrigger("Torcida");
            }


            //Pegando
            if (Input.GetKey(KeyCode.G))
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
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao && !morto)
        {
            animPlayer.SetTrigger("Pular");
            move.Pular();
            estaNoChao = false;
        }
    }

    public void Interagindo()
    {
        animPlayer.SetTrigger("Interact");
        pegando = true;
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

    private void OnTriggerEnter(Collider col)
    {
        if (!morto)
        {
            if (col.gameObject.CompareTag("Espinhos"))
            {
                animPlayer.SetBool("EstaVivo", false);
                animPlayer.SetTrigger("Morte");
                morto = true;
            }
        }
        podePegar = true;
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.CompareTag("bau"))
        {
            if (Input.GetKeyUp(KeyCode.E) && podePegar)
            {
                Interagindo();

                if (!col.gameObject.GetComponent<Chest>().CloseChest() && pegando)
                {
                    
                    col.gameObject.GetComponent<Chest>().OpenChest();
                    // col.gameObject.GetComponent<Chest>().GetKey();

                    Debug.Log("bau aberto");
                    pegando = false;
                }
            }
            
        }

        if (col.gameObject.CompareTag("Key") )
        {
            Interagindo();

            if (Input.GetKeyUp(KeyCode.E) && podePegar && pegando)
            {
                col.gameObject.GetComponent<Key>().GetKey();
                keys++;
                pegando=false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        podePegar = false;
        pegando = false;
    }
}
