using UnityEngine;

namespace Common.Command
{
	/// <summary>
	/// Defines an asynchronous command with execute and undo operations.
	/// </summary>
	public interface ICommand
	{
		/// <summary>
		/// Executes the command asynchronously.
		/// </summary>
		Awaitable Execute();

		/// <summary>
		/// Reverts the effects of a previous <see cref="Execute"/> call asynchronously.
		/// </summary>
		Awaitable Undo();
	}
}


