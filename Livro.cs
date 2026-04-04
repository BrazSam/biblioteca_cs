namespace Biblioteca2;
public class Livro
{
    public string Titulo = "";
    public string SubTitulo = "";
    public string Escritor = "";
    public string Editora = "";
    public string Genero = "";
    public int AnoPublicacao;
    public string TipoDaCapa = "";
    public int NumeroDePaginas;
    //construtor
    public Livro()
    {
        
    }
    public Livro(string titulo)
    {
        this.Titulo = titulo;
    }
    public Livro(string titulo = "", string subTitulo = "", string escritor = "", 
             string editora = "", string genero = "", int anoPublicacao = 0, 
             string tipoDaCapa = "", int numeroDePaginas = 0)
    {
        Titulo = titulo;
        SubTitulo = subTitulo;
        Escritor = escritor;
        Editora = editora;
        Genero = genero;
        AnoPublicacao = anoPublicacao;
        TipoDaCapa = tipoDaCapa;
        NumeroDePaginas = numeroDePaginas;
    }
}