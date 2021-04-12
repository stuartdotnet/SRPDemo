namespace SRP1._3__RefactorForAbstraction
{
	public interface ILogger
	{
		void LogInfo(string message);
		void LogWarning(string message);
		void LogError(string message);
	}
}