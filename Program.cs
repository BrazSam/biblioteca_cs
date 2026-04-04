namespace Biblioteca2;
internal class Program
{   
    //Thiago Kovalski e Samuel Braz
    List<Livro> livrosLista = new List<Livro>();
    internal static List<Leitor> Leitores = new List<Leitor>(); //deixei internal static aqui
    Program()
    {
        // cria leitores
        Leitor leitor1 = new Leitor("Luciano Coelho", 17, "1234567");
        Leitor leitor2 = new Leitor("Abc Bolinhas", 12, "11111");

        // cria livros
        Livro l1 = new Livro("O contador de Histórias", "Memórias de vida e música", "Dave Grohl", "Editora1", "Biografia", 2021, "Dura", 300);

        Livro l2 = new Livro("O guia do Mochileiro das Galáxias", "Não entre em pânico", "Douglas Adams", "Editora2", "Ficção Científica", 1979, "Dura", 200);

        Livro l3 = new Livro("Memórias de um legionário", anoPublicacao:2021);
        l3.Escritor = "Dado Villa-Lobos";

        Livro l4 = new Livro();
        l4.Titulo = "O Senhor dos Anéis";
        l4.Escritor = "J.R.R. Tolkien";
        l4.AnoPublicacao = 1954;

        //add os livros a uma lista
        livrosLista.Add(l1);
        livrosLista.Add(l2);
        livrosLista.Add(l3);
        livrosLista.Add(l4);

        // adiciona livros aos leitores
        leitor1.AdicionarLivro(l1);
        leitor1.AdicionarLivro(l2);
        leitor1.AdicionarLivro(l3);
        leitor2.AdicionarLivro(l4);

        // não temos a necessidade da variável de instancia para poder criar e adicionar um livro, objeto
        leitor2.AdicionarLivro( new Livro("Cdf", anoPublicacao:2024) );

        // adiciona leitores a lista de leitores
        Leitores.Add(leitor1);
        Leitores.Add(leitor2);
        Leitores.Add(new Leitor("Joãozinho", 10));


        bool usuarioDesejaSair = false;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=========================================================");
            Console.WriteLine("                   MENU DA BIBLIOTECA                    ");
            Console.WriteLine("=========================================================");
            Console.WriteLine(" 1 - Cadastrar novo Leitor (CRUD)"); //feito 
            Console.WriteLine(" 2 - Listar todos os Leitores (CRUD)"); //feito 
            Console.WriteLine(" 3 - Editar dados de um Leitor (CRUD)"); //feito 
            Console.WriteLine(" 4 - Excluir um Leitor (CRUD)"); //feito 
            Console.WriteLine(" 5 - Incluir um livro para um Leitor"); //feito
            Console.WriteLine(" 6 - Editar um livro específico do Leitor");
            Console.WriteLine(" 7 - Remover um livro de um Leitor (ex: perdido)"); //feito
            Console.WriteLine(" 8 - Doar um livro para outro Leitor"); //feito
            Console.WriteLine(" 9 - Listar TODOS os Leitores e seus respectivos livros"); //feito 
            Console.WriteLine("10 - Listar um Leitor ESPECÍFICO e seus livros"); //feito 
            Console.WriteLine("11 - Pesquisar por um livro específico e mostrar o Leitor");//feito
            Console.WriteLine("12 - Adicionar Livro NOVO");//feito
            Console.WriteLine("14 - Listar todos os livros");//feito
            Console.WriteLine(" 0 - Sair do Sistema"); //feito
            Console.WriteLine("=========================================================");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();
            Console.WriteLine(); 

            switch (opcao)
            {
                  case "1":
                    Leitor novoLeitor = CadastroLeitor();
                    Leitores.Add(novoLeitor);
                    break;
                case "2":
                    ListarLeitores();
                    Console.ReadLine();
                    break;
                case "3":
                    Leitores = AlterarLeitorCadastro();
                    break;
                case "4":
                    Leitores = RemoverLeitor();
                    break;
                case "5":
                    IncluirLivroLeitor();
                    break;
                case "6":
                    EditarLivroDeLeitor();
                    break;
                case "7":
                    RemoverLivroLeitor();
                    break;
                case "8":
                    DoarLivroLeitor();
                    break;
                case "9":
                    ListarLivrosELeitores();
                    Console.ReadLine();
                    break;
                case "10":
                    ListarLeitorELivroEspecifico();
                    break;
                case "11":
                    PesquisaLivroAchaLeitor();
                    break;
                case "12":
                    livrosLista.Add(CriarNovoLivro());
                    break;
                case "14":
                    ListarLivros(livrosLista);
                    break;
                case "0":
                    Console.WriteLine("Saindo do sistema");
                    usuarioDesejaSair = true;
                    break;
                default:
                    System.Console.WriteLine("Digite uma opcao VALIDA!");
                    break;
            }
            if (usuarioDesejaSair)
            break;
        }
    }
    private static void Main(string[] args)
    {
        _ = new Program();
    }

    public Livro CriarNovoLivro()
    {
        System.Console.WriteLine("Digite o titulo do Livro: ");
        string tituloL = Console.ReadLine();
        
        System.Console.WriteLine("Digite o subTitulo do Livro: ");
        string subTituloL = Console.ReadLine();

        System.Console.WriteLine("Digite o escritor do Livro: ");
        string escritorL = Console.ReadLine();

        System.Console.WriteLine("Digite o editora do Livro: ");
        string editoraL = Console.ReadLine();

        System.Console.WriteLine("Digite o genero do Livro: ");
        string generoL = Console.ReadLine();

        System.Console.WriteLine("Digite o ano de Publicacao do Livro: ");
        int anoPublicacaoL = Convert.ToInt32(Console.ReadLine());

        System.Console.WriteLine("Digite o tipo de capa do Livro: ");
        string tipoDaCapaL = Console.ReadLine();

        System.Console.WriteLine("Digite o ano de Publicacao do Livro: ");
        int numeroDePaginasL = Convert.ToInt32(Console.ReadLine());

        return new Livro(tituloL, subTituloL, escritorL, editoraL, generoL, anoPublicacaoL, tipoDaCapaL, numeroDePaginasL);
    }
    public void ListarLivros(List<Livro> livros)
    {
        foreach(Livro componenteLivro in livros)
        {
            System.Console.WriteLine($"Titulo: {componenteLivro.Titulo}, subtitulo: {componenteLivro.SubTitulo}, \nescritor: {componenteLivro.Escritor}, genero: {componenteLivro.Genero}, ano publicado: {componenteLivro.AnoPublicacao}, numero de paginas: {componenteLivro.NumeroDePaginas}\n");
        }
        Console.ReadLine();
    }






//metodos do leitor.cs para main
//só alguns detalhes na declaracao do metodo e de leitores agora fica Leitores para pegar direto na lista

 static Leitor CadastroLeitor()
    {
        while (true)
        {
            Console.Write("Digite o NOME do Leitor: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a IDADE do Leitor: ");
            byte idade = Convert.ToByte(Console.ReadLine());

            Console.Write("Digite o CPF do Leitor: ");
            string cpf = Console.ReadLine();

            if (Leitores.Exists(l => l.Cpf == cpf))
            {
                Console.WriteLine("O CPF ja esta cadastrado!");
                continue;
            }
            Leitor leitor = new Leitor(nome, idade, cpf);
            return leitor;
        }
    }

    static void ListarLeitores()
    {
        foreach (Leitor l in Leitores)
        {
            Console.WriteLine($"NOME: {l.Nome}, IDADE: {l.Idade}, CPF: {l.Cpf}");
        }
    }

    static List<Leitor> AlterarLeitorCadastro()
    {
        ListarLeitores();
        Console.Write("Digite o CPF que deseja alterar o cadastro: ");
        string cpf = Console.ReadLine();

        int i;
        for (i = 0; i < Leitores.Count; i++)
        {
            if (Leitores[i].Cpf == cpf) break;
        }

        Console.WriteLine($"Altera o NOME do leitor: {Leitores[i].Nome}");
        Console.Write("Novo nome: ");
        string novoNome = Console.ReadLine();

        Console.WriteLine($"Altera a IDADE do leitor: {Leitores[i].Idade}");
        Console.Write("Nova idade: ");
        byte novaIdade = Convert.ToByte(Console.ReadLine());

        Leitor novoLeitor = new Leitor(novoNome, novaIdade, cpf);
        Leitores[i] = novoLeitor;

        return Leitores;
    }

    static List<Leitor> RemoverLeitor()
    {
        ListarLeitores();
        Console.Write("Digite o CPF que deseja remover o cadastro: ");
        string cpf = Console.ReadLine();

        for (int i = 0; i < Leitores.Count; i++)
        {
            if (Leitores[i].Cpf == cpf)
            {
                Console.WriteLine($"Leitor: {Leitores[i].Nome} removido com sucesso!");
                Leitores.Remove(Leitores[i]);
                Console.ReadLine();
            }
        }
        return Leitores;
    }

    static void IncluirLivroLeitor()
    {
        Console.Clear();
        ListarLivrosELeitores();

        Console.Write("Digite o cpf do Leitor para incluir o LIVRO: ");
        string cpf = Console.ReadLine();

        Leitor nomeIncluirLivro = null;
        foreach (Leitor leitor in Leitores)
        {
            if (leitor.Cpf == cpf) nomeIncluirLivro = leitor;
        }

        Console.Write("Digite o TITULO do livro para ADICIONAR: ");
        string tituloLivroAdicionado = Console.ReadLine();

        nomeIncluirLivro.AdicionarLivro(new Livro(tituloLivroAdicionado));
        Console.WriteLine($"O leitor {nomeIncluirLivro.Nome} teve o livro: {tituloLivroAdicionado} adicionado!");
        Console.ReadLine();
    }

    static void EditarLivroDeLeitor()
    {
        Console.Clear();
        ListarLivrosELeitores();
        Console.Write("Digite o CPF do leitor: ");
        string cpf = Console.ReadLine();

        Leitor leitor = null;
        foreach (Leitor l in Leitores)
        {
            if (l.Cpf == cpf) { leitor = l; break; }
        }

        Console.WriteLine("\nLivros do leitor:");
        foreach (Livro l in leitor.LivrosLeitor)
        {
            Console.WriteLine($"- {l.Titulo}");
        }

        Console.Write("\nDigite o título do livro que deseja editar: ");
        string titulo = Console.ReadLine();

        Livro livro = null;
        foreach (Livro l in leitor.LivrosLeitor)
        {
            if (l.Titulo == titulo) { livro = l; break; }
        }

        Console.Clear();
        Console.WriteLine("EDITANDO LIVRO\n");
        Console.Write("Novo título: ");
        livro.Titulo = Console.ReadLine();
        Console.Write("Novo subtítulo: ");
        livro.SubTitulo = Console.ReadLine();
        Console.Write("Novo escritor: ");
        livro.Escritor = Console.ReadLine();
        Console.Write("Nova editora: ");
        livro.Editora = Console.ReadLine();
        Console.Write("Novo gênero: ");
        livro.Genero = Console.ReadLine();
        Console.Write("Novo ano de publicação: ");
        livro.AnoPublicacao = int.Parse(Console.ReadLine());
        Console.Write("Novo tipo da capa: ");
        livro.TipoDaCapa = Console.ReadLine();
        Console.Write("Novo número de páginas: ");
        livro.NumeroDePaginas = int.Parse(Console.ReadLine());
        Console.WriteLine("\nLivro editado com sucesso!");
        Console.ReadLine();
    }

    static void RemoverLivroLeitor()
    {
        Console.Clear();
        ListarLivrosELeitores();

        Console.Write("Digite o cpf do Leitor para remover o LIVRO: ");
        string cpf = Console.ReadLine();

        Leitor nomeRemoverLivro = null;
        foreach (Leitor leitor in Leitores)
        {
            if (leitor.Cpf == cpf) nomeRemoverLivro = leitor;
        }

        Livro livroRemover = new Livro();
        Console.Write("Digite o TITULO do livro para remover: ");
        string tituloLivroRemovido = Console.ReadLine();

        foreach (Livro livro in nomeRemoverLivro.LivrosLeitor)
        {
            if (livro.Titulo == tituloLivroRemovido) { livroRemover = livro; break; }
        }

        nomeRemoverLivro.RemoverLivro(livroRemover);
        Console.WriteLine($"O leitor {nomeRemoverLivro.Nome} teve o livro: {tituloLivroRemovido} removido!");
        Console.ReadLine();
    }

    static void DoarLivroLeitor()
    {
        Console.Clear();
        ListarLivrosELeitores();

        Console.Write("Digite o cpf do Leitor que vai DOAR o LIVRO: ");
        string cpfDoador = Console.ReadLine();

        Leitor leitorDoador = null;
        foreach (Leitor leitor in Leitores)
        {
            if (leitor.Cpf == cpfDoador) leitorDoador = leitor;
        }

        Livro livroDoado = new Livro();
        Console.Write("Digite o titulo do LIVRO a ser DOADO: ");
        string tituloLivro = Console.ReadLine();

        foreach (Livro livro in leitorDoador.LivrosLeitor)
        {
            if (livro.Titulo == tituloLivro) { livroDoado = livro; break; }
        }

        Console.Write("Digite o cpf do leitor que vai receber o LIVRO: ");
        string cpfRecebedor = Console.ReadLine();

        Leitor leitorRecebedor = null;
        foreach (Leitor leitor in Leitores)
        {
            if (leitor.Cpf == cpfRecebedor) leitorRecebedor = leitor;
        }

        leitorDoador.LivrosLeitor.Remove(livroDoado);
        leitorRecebedor.LivrosLeitor.Add(livroDoado);
    }

    static void ListarLivrosELeitores()
    {
        foreach (Leitor l in Leitores)
        {
            Console.WriteLine($"NOME: {l.Nome}, IDADE: {l.Idade}, CPF: {l.Cpf}");
            Console.WriteLine("Livros:");
            foreach (Livro livro in l.LivrosLeitor)
            {
                Console.WriteLine($" - {livro.Titulo}");
            }
            Console.WriteLine();
        }
    }

    static void ListarLeitorELivroEspecifico()
    {
        ListarLeitores();
        bool encontrouOCPF = false;

        while (!encontrouOCPF)
        {
            Console.Write("Digite o CPF que deseja LISTAR OS LIVROS: ");
            string cpf = Console.ReadLine();

            int i;
            for (i = 0; i < Leitores.Count; i++)
            {
                if (Leitores[i].Cpf == cpf) { encontrouOCPF = true; break; }
            }

            if (encontrouOCPF)
            {
                Console.WriteLine($"O leitor: {Leitores[i].Nome}, tem os seguintes livros: ");
                foreach (Livro l in Leitores[i].LivrosLeitor)
                {
                    Console.WriteLine(l.Titulo);
                }
            }
            else
            {
                Console.WriteLine($"Nao foi encontrado um leitor com o CPF: {cpf}\n");
            }
        }
        Console.ReadLine();
    }

    static void MostrarLivros()
    {
        foreach (Leitor l in Leitores)
        {
            foreach (Livro livro in l.LivrosLeitor)
            {
                Console.WriteLine($" - {livro.Titulo}");
            }
        }
    }

    static void PesquisaLivroAchaLeitor()
    {
        MostrarLivros();
        Console.Write("Digite o TITULO do Livro para encontrar o Leitor: ");
        string tituloLivro = Console.ReadLine();

        foreach (Leitor leitor in Leitores)
        {
            foreach (Livro livro in leitor.LivrosLeitor)
            {
                if (livro.Titulo == tituloLivro)
                {
                    Console.WriteLine($"O livro com o titulo {tituloLivro} pertence ao leitor: {leitor.Nome}");
                    Console.ReadLine();
                }
            }
        }
    }

}