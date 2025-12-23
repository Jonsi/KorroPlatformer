using UnityEngine;

namespace Common
{
    /// <summary>
    /// Utility methods for working with Awaitables.
    /// </summary>
    public static class AwaitableUtility
    {
        /// <summary>
        /// Returns an already completed Awaitable.
        /// </summary>
        /// <returns>A completed Awaitable instance.</returns>
        public static Awaitable Completed() => CompletedAwaitable.Instance;

        private static class CompletedAwaitable
        {
            private static readonly AwaitableCompletionSource SCompletionSource = new();

            static CompletedAwaitable()
            {
                SCompletionSource.SetResult();
            }

            public static Awaitable Instance => SCompletionSource.Awaitable;
        }
    }
}

