using Newtonsoft.Json;

namespace GitLabApiClient.Models.Issues.Requests
{
    /// <summary>
    /// Used to delete links between issues.
    /// </summary>
    public sealed class DeleteIssueLinkRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteIssueLinkRequest"/> class.
        /// </summary>
        /// <param name="title">Title of the issue.</param>
        public DeleteIssueLinkRequest()
        {
        }

        /// <summary>
        /// The type of the relation (“relates_to”, “blocks”, “is_blocked_by”), defaults to “relates_to”).
        /// </summary>
        [JsonProperty("link_type")]
        public IssueLinkTypeEnum? LinkType { get; set; }
    }
}
