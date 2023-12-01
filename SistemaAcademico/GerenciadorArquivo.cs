using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace SistemaAcademico;

public class GerenciadorArquivo
{
  public List<Aluno> Alunos = new List<Aluno>();
  public List<Disciplina> Disciplinas = new List<Disciplina>();
  public GerenciadorArquivo()
  {
    this.IniciarListas();
  }

  public void IniciarListas()
  {
    if (File.Exists("alunos.json") == false)
    {
      File.Create("alunos.json").Close();
    }
    if (File.Exists("disciplinas.json") == false)
    {
      File.Create("disciplinas.json").Close();
    }

    using(StreamReader reader = new StreamReader(File.OpenRead("alunos.json")))
    {
      try{
      string content = reader.ReadToEnd();
      this.Alunos = JsonSerializer.Deserialize<List<Aluno>>(content);
      reader.Close();
    }
    catch{

    }
    }
  
    using(StreamReader reader = new StreamReader(File.OpenRead("disciplinas.json")))
    {
      try{
      string content = reader.ReadToEnd();
      this.Disciplinas = JsonSerializer.Deserialize<List<Disciplina>>(content);
      reader.Close();
      }
      catch{

      }
    }

  }

  public void SalvarListas()
  {
    if(File.Exists("alunos.json") == true)
    {
      File.Delete("alunos.json");
    }

    if(File.Exists("disciplinas.json") == true)
    {
      File.Delete("disciplinas.json");
    } 

    using(StreamWriter writer = new StreamWriter(File.Open("alunos.json", FileMode.OpenOrCreate)))
    {
      string json = JsonSerializer.Serialize<List<Aluno>>(Alunos);
      writer.WriteLine(json);
      writer.Flush();
      writer.Close();
    }
    using(StreamWriter writer = new StreamWriter(File.Open("disciplinas.json", FileMode.OpenOrCreate)))
    {
      string json = JsonSerializer.Serialize<List<Disciplina>>(Disciplinas);
      writer.WriteLine(json);
      writer.Flush();
      writer.Close();
    }
  }

  public void CadastrarAluno(Aluno aluno)
  {
    this.Alunos.Add(aluno);
  }

  public void CadastrarDisciplina(Disciplina disciplina)
  {
    this.Disciplinas.Add(disciplina);
  }
}