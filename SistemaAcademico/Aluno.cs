namespace SistemaAcademico;

public class Aluno
{
    public String Nome { get; set; }
    public String Matricula { get; set; }
    public DateTime DataNascimento {get;set;}
    public List<Disciplina> DisciplinasMatriculadas {get;set;}

    public void Enturmar(Disciplina disciplina) 
    {
        if(this.DisciplinasMatriculadas == null)
        {
            this.DisciplinasMatriculadas = new List<Disciplina>();
        }
        
        this.DisciplinasMatriculadas.Add(disciplina);
    }
}