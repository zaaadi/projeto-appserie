using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            ListarSeries();
                            break;
                        case "2":
                           InserirSerie();
                            break;
                        case "3":
                            AtualizarSerie();
                            break;
                        case "4":
                            ExcluirSerie();
                            break;
                        case "5":
                           VisualizarSerie();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        
                        default: 
                        
                        throw new ArgumentOutOfRangeException();
                    }
                    opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigada por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceserie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceserie);
        }
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceserie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceserie);

            Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceserie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
             Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Ínicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

        serie atualizaserie = new serie(id: indiceserie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
        repositorio.Atualiza(indiceserie, atualizaserie);
     }
    private static void ListarSeries()
    { 
        Console.WriteLine("Listar séries");

        var lista = repositorio.Lista();
        
        
        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhuma série cadastrada.");
            return;
        }
        foreach (var serie in lista)
        {
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(),serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
        }
    }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.WriteLine("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o Título da Série: ");
        string entradaTitulo = Console.ReadLine();

        Console.WriteLine("Digite o Ano de Ínicio da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite a Descrição da Série: ");
        string entradaDescricao = Console.ReadLine();

        serie novaserie = new serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
        repositorio.Insere(novaserie);
     }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor!!! <3");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
       }
     }
   }
