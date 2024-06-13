[System.Serializable]
public class QuizAndAnswer
{
    
    public string Question;
    public string[] Answer;
    public int CorrectAnswer;

    public QuizAndAnswer(string text, string[] answers, int answer)
    {
        Question = text;
        Answer = answers;
        CorrectAnswer = answer;
    }
}
