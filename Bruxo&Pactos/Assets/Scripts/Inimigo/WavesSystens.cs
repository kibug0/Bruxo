using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesSystens : MonoBehaviour
{
    #region classe de outros scripts
    public Fasecameracontroler Fcc;

    #endregion

    #region Variavies

    //Enum criado para os estados possiveis da wave spawning = spawnando; wating = esperando; couunting = contando;
    public enum SpawnState{desligado, Spawning, wating, couunting, finalizado}
    
    

    //Classe que eu criei para cada inimigo que pode aparecer numa wave
    [System.Serializable]
    public class inimigo
    {
        //Nome do inimigo
        public string Name;
        //O transform do inimigo para chamar ele
        public Transform enemy;

        //o nivel do inimigo por enquanto não esta sendo usado
        public int nivelEnemy;
    }

    //Essa é um tipo de classe que eu criei para definir as ondas de inimigos tanto com nome = Name; 
    [System.Serializable]
    public class Wave
    {
        //nome da wave
        public string Name;
        
        
        //tipos de inimigos = Inimigo; eu usei a classe inimigo que eu criei logo a cima e fiz um array dela para poder escolher mais de um tipo de inimigo
        public inimigo[] Inimigo;

        //quantidade de inimigos na onda = count;
        public int count;

        //tempo de drope de um inimigo a outros
        public float rate;

        //Frequencia de inimigos que aparecem
        public int[] Poucafrec;
        public int[] Mediafrec;
        public int[] Muitafrec;

        
    }
    
    //Essa é uma variavel para ver os numeros que não estão publicos para a unity
    public int test;

    //Um array que criei usando a classe que eu criei logo a cima para pode definir como cada onda ira se comportar
    public Wave[] wave;

    //uma função int que serve para chamar a onda certa seguindo ate a ultima
    private int nextwave;

    
    //Locais onde os inimigos podem ser chamados
    public Transform[] spawnPoints;

    //O tempo de duração entre as waves ela serve para reiniciar o wavecountdown para esse valor não ser perdido
    public float timebetweenwaves = 5f;

    //Aki ele rescebe o tempo entre as waves para começar a contar alterando o numero como se fosse em segundos
    public float wavecountdown;

    //Ele serve para procurar a cada 1 segundo se os inimigos ainda estão vivos
    private float searchCountdown = 1f;

    // aki eu ativo o enum para ir alterando ela pelos os paremetros feitos a cima no enum
    public SpawnState state = SpawnState.desligado;

    
    #endregion

    #region Start
    void Start()
    {
        if(spawnPoints.Length == 0)
        {
            Debug.LogError("Não tem spawnpoint de referencia.");
        }

        //coloca o contador de uma wave entre wave com o tempo certo
        wavecountdown = timebetweenwaves;
    }
    #endregion

    #region update
    void Update()
    {  
        if(state != SpawnState.desligado)
        
        {   
            //Enquanto tiver inimigos vivo ele não fara os ifs a baixo
            if(state == SpawnState.wating)
            {
                //Checa caso os inimigos ainda estão vivos
                if(!EnemyIsAlive())//EnemyIsAlive()==false
                {
                    //Começa uma nova rodada
                    Wavecompleted();
                    
                }
                else
                {
                    return;
                }

            }

            //Se o tempo for menor ou igual a 0
            if(wavecountdown <= 0)
            {
                //Se o estado não estiver em estado de spawnando ele ativa a corrotina
                if(state != SpawnState.Spawning)
                {
                    //Começa a Spawnar as waves

                    StartCoroutine(SpawnWave(wave[nextwave]));

                }
            
            
            }
            else
            {
                //Se o tempo for maior que 0 ele vai tirando de 1 em 1 segundo ate dar 0
                wavecountdown -= Time.deltaTime;
            }
        }
        else
        {
            return;
        }
        
    }
    #endregion

    //Para confirmar se a wave acbou e ir para a proxima ou retornar para a primeira ou mostrar o fim
    #region Wave completa
    void Wavecompleted()
    {
        
        Debug.Log("wave completa!");

        state = SpawnState.couunting;

        //coloca o contador de uma wave entre wave com o tempo certo
        wavecountdown = timebetweenwaves;

        if(nextwave + 1 > wave.Length - 1)
        {
            Fcc.TodosSeForam();
            //nextwave = 0;
            state = SpawnState.finalizado;
            Debug.Log("completou todas as waves. Looping...");

        }
        else
        {
          nextwave++;            
        }



    }
    #endregion

    #region Verificador de vida dos inimigos
    bool EnemyIsAlive()
    {
        //
        searchCountdown -= Time.deltaTime;

        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            // ve so o a quantidade de game objects com a tag Inimigo
           if(GameObject.FindGameObjectsWithTag("Inimigo").Length == 0)//GameObject.FindGameObjectsWithTag("Inimigo") == null: aki ele faria um loop obrigatorio para encontrar o objeto com essa tag
           {
               //Fim da wave
            state = SpawnState.desligado;
            return false;

           }

        }
        return true;
    }
    #endregion

    //IEnumerator e a função que spawna os inimigos
    #region IE e SpawnEnemys
    IEnumerator SpawnWave(Wave _wave)
    {
        //Debug.Log("Spawnando wave: " + _wave.name);
        int maior = 0;
        int media = 0;
        int menor = 0;

        int rand = 0;

        //Coloca o estadu de spawnando
        state = SpawnState.Spawning;

        //spawn com um looping para pegar todos os pontos de spawn
        for(int i = 0 ; i < _wave.count; i++)
        {
            rand = Random.Range(1,4);
            test = rand;
            
            //função para chamar os inimigos

            //Mais frequente
            /*if(rand <= 5)
            {
                if(Muitafrec.Length == 1)
                {
                    SpawnEnemys(_wave.Inimigo[0].enemy);
                }
                else
                {
                    SpawnEnemys(_wave.Inimigo[Random.Range(0,Muitafrec.Length)].enemy);
                }

            }*/
            //SpawnEnemys(_wave.enemy);

            #region Rand 1 de maior frequancia
            if(rand == 1)
            {
            //Maior frequancia
             //if(i<=_wave.count*0.5)
             if(maior<=_wave.count*0.5)
             {
                 //Pega os que aparecem com mais frequencia
                SpawnEnemys(_wave.Inimigo[_wave.Muitafrec[Random.Range(0,_wave.Muitafrec.Length)]].enemy);
                maior ++;

             }
             else if(media<=_wave.count*0.3)
             {
                rand = 2;
             }
             else if(menor>=_wave.count*0.2)
             {
                rand = 3;
             }
             
             

            }
            #endregion


            #region Rand 2 de media frequancia
            if(rand == 2)
            {
            //Media frequancia
            //if(i>=_wave.count*0.3 && i<=_wave.count*0.2)
            if(media<=_wave.count*0.3)
            {
                //pega os com frequancia media
                SpawnEnemys(_wave.Inimigo[_wave.Mediafrec[Random.Range(0,_wave.Mediafrec.Length)]].enemy);
                media++;

            }

            else if(maior<=_wave.count*0.5)
             {
                 //Pega os que aparecem com mais frequencia
                SpawnEnemys(_wave.Inimigo[_wave.Muitafrec[Random.Range(0,_wave.Muitafrec.Length)]].enemy);
                
                maior ++;
             }
             else if(menor<=_wave.count*0.2)
             {
                rand = 3;
             }
            }
            #endregion


            #region Rand 3 de menor frequancia
            if(rand == 3)
            {
            //Menor frequancia
            //if(i>=_wave.count*0.2)
            if(menor<=_wave.count*0.2)
            {
                //Pega os com pouca frequancia
                SpawnEnemys(_wave.Inimigo[_wave.Poucafrec[Random.Range(0,_wave.Poucafrec.Length)]].enemy);
                menor++;

            }
            else if(maior<=_wave.count*0.5)
             {
                 //Pega os que aparecem com mais frequencia
                 SpawnEnemys(_wave.Inimigo[_wave.Muitafrec[Random.Range(0,_wave.Muitafrec.Length)]].enemy);
                
                maior ++;
             }
             else if(media<=_wave.count*0.3)
             {
                //pega os com frequancia media
                SpawnEnemys(_wave.Inimigo[_wave.Mediafrec[Random.Range(0,_wave.Muitafrec.Length)]].enemy);
                
                media++;
             }
            }
            #endregion
            
            //SpawnEnemys(_wave.Inimigo[0].enemy);

            //Ele espera a determinada quantidade de segundos estabelecida. caso queira colocar um Delay era so colocar ao inves de 1f/_wave.rate colocar _wave.Delay
            yield return new WaitForSeconds( 1f/_wave.rate );

        }

        //Coloca o state em espera
        state = SpawnState.wating;

        //Aqui ele simplesmente ignora o IEnumerator e termina ele
        yield break;
    }



    void SpawnEnemys(Transform _Enemy)
    {
        //Spawna os inimigos
        Debug.Log("Espawnando o inimigo: " + _Enemy.name);

        
        //Seta a posição de um spawnPoint aleatorio do Array para colocar o inimigo
        Transform _Sp = spawnPoints[ Random.Range(0, spawnPoints.Length) ];
        Instantiate(_Enemy, _Sp.position, _Sp.rotation);
        
    }

    public void começar()
    {
        state = SpawnState.couunting;

    }


    
    #endregion
}
