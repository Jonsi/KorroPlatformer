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
            private static readonly AwaitableCompletionSource s_completionSource = new();

            static CompletedAwaitable()
            {
                s_completionSource.SetResult();
            }

            public static Awaitable Instance => s_completionSource.Awaitable;
        }
    }
}

