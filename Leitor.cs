namespace Biblioteca2;

internal class Leitor //deixei internal
{
    //aqui ajeitei um pouco os atributos pra nao ter idade negativa e cpf repetido
    public string Nome {get; set;}
    private byte _idade;
    internal byte Idade
    {
        get => _idade;
        set
        {
            if (value < 0)
                throw new Exception("Idade não pode ser negativa!");
            _idade = value;
        }
    }

    private string _cpf;
    internal string Cpf
    {
        get => _cpf;
        set
        {
            value = value?.Trim();
            if (string.IsNullOrEmpty(value))
                throw new Exception("CPF não pode ser vazio!");
            if (Program.Leitores.Any(l => l.Cpf == value))
                throw new Exception("CPF já cadastrado!");
            _cpf = value;
        }
    }
    public List<Livro> LivrosLeitor = new List<Livro>();

    //construtor
    public Leitor()
    {
        
        
    }
    public Leitor(string nome, byte idade)
    {
        Nome = nome;
        Idade = idade;
        
    }

    //construtor 2 + cpf
    public Leitor(string nome, byte idade, string cpf)
    {
        Nome = nome;
        Idade = idade;
        Cpf = cpf;
    }
    
    internal void AdicionarLivro(Livro livro)
    {
        LivrosLeitor.Add(livro);
    }

    internal void RemoverLivro(Livro livro)
    {
        LivrosLeitor.Remove(livro);
    }
}