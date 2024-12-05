using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator animPlayer;
    [SerializeField] private MovementPlayer move;
    private bool estaNoChao = true;
    public int keys = 0;
    public bool life;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animPlayer = GetComponent<Animator>();
        move = GetComponent<MovementPlayer>();
        life = true;
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

    void Interagir()
    {
        animPlayer.SetTrigger("Interact");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Chao"))
        {
            animPlayer.SetBool("NoChao", true);
            estaNoChao = true;
        }
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
        if (other.gameObject.CompareTag("Espinhos"))
        {
            if (life == true)
            {
                life = false;
                animPlayer.SetTrigger("Morte");
            }

        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Chest"))
        {
            Animator animChest = col.gameObject.GetComponent<Animator>();
            if(Input.GetKey(KeyCode.E))
            {
                Interagir();
                if (!animChest.GetBool("Chest"))
                {
                    keys++;
                }
                animChest.SetBool("Chest", true);
                Debug.Log(keys);

            }
            
        }
        if (col.gameObject.CompareTag("Door"))
        {
            Animator animDoor = col.gameObject.GetComponent<Animator>();
            if (Input.GetKey(KeyCode.E))
            {
                Interagir();
                if (!animDoor.GetBool("OpenNoor") && keys > 0)
                {
                    animDoor.SetBool("OpenNoor", true);
                    Invoke("ProximaFase", 3f);
                    keys--;
                }

                Debug.Log(keys);

            }

        }
    }
    public void ProximaFase()
    {
        Debug.Log("Muda de Fase"); // Aqui vc linka com algum codigo de mudar de fase
    }
    
}
