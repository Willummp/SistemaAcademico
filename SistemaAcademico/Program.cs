using SistemaAcademico;

internal class Program
{
    private static GerenciadorArquivo gerenciadorArquivo ;
    private static void Main(string[] args)
    {
        var stopKey = "0";
        var selectedMenu = "";
        gerenciadorArquivo = new GerenciadorArquivo();

        while (stopKey != selectedMenu)
        {
            Console.WriteLine("1 - Cadastrar Aluno");
            Console.WriteLine("2 - Cadastrar Disciplina");
            Console.WriteLine("3 - Enturmar Aluno em Disciplina");
            Console.WriteLine("4 - Exibir Quadro de horario de Aluno");
            Console.WriteLine("0 - Sair");

            selectedMenu = Console.ReadLine();


            ExecutarOpcaoSelecionada(selectedMenu);

        }
    }
    private static void ExecutarOpcaoSelecionada(string selectedMenu)
    {
        switch (selectedMenu)
        {
            case "1":
                CadastrarAluno();
                break;
            case "2":
                CadastrarDisciplina();
                break;
            case "3":
                EnturmarAluno();
                break;
            case "4":
                ExibirQuadroDeHorario();
                break;
            case "0":
                gerenciadorArquivo.SalvarListas();
                Console.WriteLine("Saindo...");
                break;
            default:
                Console.WriteLine("Opcao invalida...");
                break;
        }
    }

    private static void ExibirQuadroDeHorario()
    {
        Console.WriteLine("Digite a matricula do aluno:");
        string matricula = Console.ReadLine();
        Aluno aluno = gerenciadorArquivo.Alunos.FirstOrDefault(m => m.Matricula == matricula);
        if (aluno == null)
        {
            Console.WriteLine("Aluno nao encontrado");
            return;
        }
        Console.WriteLine($"Aluno: {aluno.Nome}  - Matricula: {aluno.Matricula}: ");
        Console.WriteLine("===============Quadro de Horario================");
        foreach (var disciplina in aluno.DisciplinasMatriculadas)
        {
            Console.WriteLine($"Disciplina: {disciplina.Nome} - Professor: {disciplina.Professor} - Hora de inicio: {disciplina.HoraInicio} - Duracao: {disciplina.Duracao}");
        }
    }

    private static void EnturmarAluno()
    {
        Console.WriteLine("Digite a matricula do aluno:");
        string matricula = Console.ReadLine();
        Aluno aluno = gerenciadorArquivo.Alunos.FirstOrDefault(m => m.Matricula == matricula);
        if (aluno == null)
        {
            Console.WriteLine("Aluno nao encontrado");
            return;
        }
        Console.WriteLine("Digite o nome da disciplina:");
        string nomeDisciplina = Console.ReadLine();
        Disciplina disciplina = gerenciadorArquivo.Disciplinas.FirstOrDefault(m => m.Nome == nomeDisciplina);
        if (disciplina == null)
        {
            Console.WriteLine("Disciplina nao encontrada");
            return;
        }

        aluno.Enturmar(disciplina);
    }

    private static void CadastrarAluno()
    {
        Aluno aluno = new Aluno();
        Console.WriteLine("Digite o nome do aluno:");
        aluno.Nome = Console.ReadLine();
        Console.WriteLine("Digite a matricula do aluno:");
        aluno.Matricula = Console.ReadLine();
        Console.WriteLine("Digite a data de nascimento do aluno: (dd/mm/yyyy)");
        aluno.DataNascimento = Convert.ToDateTime(Console.ReadLine());
        gerenciadorArquivo.CadastrarAluno(aluno);
    }

    private static void CadastrarDisciplina()
    {
        Disciplina disciplina = new Disciplina();
        Console.WriteLine("Digite o nome da disciplina:");
        disciplina.Nome = Console.ReadLine();
        Console.WriteLine("Digite o nome do professor:");
        disciplina.Professor = Console.ReadLine();
        Console.WriteLine("Digite a hora de inicio da disciplina:");
        disciplina.HoraInicio = TimeOnly.Parse(Console.ReadLine());
        Console.WriteLine("Digite a duracao da disciplina:");
        disciplina.Duracao = TimeOnly.Parse(Console.ReadLine());
        gerenciadorArquivo.CadastrarDisciplina(disciplina);
    }


}