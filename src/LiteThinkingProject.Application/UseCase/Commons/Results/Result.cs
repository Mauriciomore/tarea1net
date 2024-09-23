namespace LiteThinkingProject.Application.UseCase.Commons.Results
{
    public class Result<T>(T data, ResultType resultType, params string[] errors)
    {
        public ResultType ResultType { get; } = resultType;

        public IEnumerable<string> Errors { get; } = errors;

        public T Data { get; } = data;
    }
}
