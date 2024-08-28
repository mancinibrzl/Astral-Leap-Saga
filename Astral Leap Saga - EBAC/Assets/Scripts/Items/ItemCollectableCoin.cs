using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    public Collider Collider;

    public bool collect = false;

    public float lerp = 5f;
    public float minDistance = 1f;
    public float flickerSpeed = 5.0f;
    public float minAlpha = 0.3f;
    public float maxAlpha = 1.0f;

    private SpriteRenderer spriteRenderer;
    private MeshRenderer meshRenderer;
    private Material material;

    
    private void Start()
    {
        //Pega o componente SpriteRenderer do GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Pega o componente MeshRenderer, se o objeto for 3D
        meshRenderer = GetComponent<MeshRenderer>();

        if (meshRenderer != null)
        {
            material = meshRenderer.material;
        }

        CoinAnimatorManager.Instance.RegisterCoin(this);
    }
    
    protected override void OnCollect()
    {
        base.OnCollect();
        GetComponent<Collider>().enabled = false;
        collect = true;
        PlayerController.Instance.Bounce();
        ItemManager.Instance.AddCoins();
        GetComponent<Collider>().enabled = false;
    }
    protected override void Collect()
    {
        OnCollect();
    }

    private void Update()
    {
        // Calcula o alpha usando uma função seno
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, Mathf.PingPong(Time.time * flickerSpeed, 1));

        // Aplica o efeito piscante em SpriteRenderer (2D)
        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
        }
        // Aplica o efeito piscante em MeshRenderer (3D)
        else if (meshRenderer != null && material != null)
        {
            Color color = material.color;
            material.color = new Color(color.r, color.g, color.b, alpha);

        }

        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position)<minDistance)
        {
            //HideItens();
            Destroy(gameObject);
        }
    }

}
