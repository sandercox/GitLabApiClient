using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GitLabApiClient.Internal.Http;
using GitLabApiClient.Models.Runners.Requests;
using GitLabApiClient.Models.Runners.Responses;
using GitLabApiClient.Models.Job.Responses;

namespace GitLabApiClient
{
    /// <summary>
    /// Used to query GitLab API to retrieve, modify, delete runners.
    /// <exception cref="GitLabException">Thrown if request to GitLab API fails</exception>
    /// <exception cref="HttpRequestException">Thrown if request to GitLab API fails</exception>
    /// </summary>
    public sealed class RunnersClient : IRunnersClient
    {
        private readonly GitLabHttpFacade _httpFacade;

        internal RunnersClient(GitLabHttpFacade httpFacade) =>
            _httpFacade = httpFacade;

        /// <summary>
        /// Retrieves registered runners.
        /// </summary>
        public async Task<IList<Runner>> GetAsync() =>
            await _httpFacade.GetPagedList<Runner>("runners");

        /// <summary>
        /// Retrieves an user matched by name.
        /// </summary>
        /// <param name="runnerId">Id of the runner.</param>
        /// <returns>Runner or NULL if it was not found.</returns>
        public async Task<Runner> GetAsync(int runnerId)
        {
            return (await _httpFacade.Get<IList<Runner>>($"runners/{runnerId}")).FirstOrDefault();
        }

        /// <summary>
        /// Updates existing user
        /// </summary>
        /// <param name="runnerId">Id of the runner.</param>
        /// <param name="request">Request to update user.</param>
        /// <returns>Newly modified user.</returns>
        public async Task<Runner> UpdateAsync(int runnerId, UpdateRunnerRequest request) =>
            await _httpFacade.Put<Runner>($"runners/{runnerId}", request);

        /// <summary>
        /// Retrieves a list of jobs running on a runner
        /// </summary>
        /// <param name="runnerId">Id of the runner to get jobs for.</param>
        /// <returns>Runner or NULL if it was not found.</returns>
        public async Task<IList<Job>> GetJobsAsync(int runnerId)
        {
            return (await _httpFacade.Get<IList<Job>>($"runners/{runnerId}/jobs?sort=desc&order_by=id"));
        }

        /// <summary>
        /// Deletes user.
        /// </summary>
        /// <param name="runnerId">Id of the runner.</param>
        public async Task DeleteAsync(int runnerId) =>
            await _httpFacade.Delete($"runners/{runnerId}");
    }
}
