using System;
using System.Collections.Generic;
using GitLabApiClient.Internal.Http.Serialization;
using GitLabApiClient.Internal.Utilities;
using GitLabApiClient.Internal.Paths;
using Newtonsoft.Json;

namespace GitLabApiClient.Models.Issues.Requests
{
    /// <summary>
    /// Used to create links between issues.
    /// </summary>
    public sealed class CreateIssueLinkRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateIssueLinkRequest"/> class.
        /// </summary>
        /// <param name="title">Title of the issue.</param>
        public CreateIssueLinkRequest(ProjectId targetProjectId, int targetIssueIid)
        {
            TargetProjectId = targetProjectId.ToString();
            TargetIssueIid = targetIssueIid;
        }

        /// <summary>
        /// The ID or URL-encoded path of the project of a target project.
        /// </summary>
        [JsonProperty("target_project_id")]
        public string TargetProjectId { get; set; }

        /// <summary>
        /// The internal ID of a target project’s issue
        /// </summary>
        [JsonProperty("target_issue_iid")]
        public int TargetIssueIid { get; set; }

        /// <summary>
        /// The type of the relation (“relates_to”, “blocks”, “is_blocked_by”), defaults to “relates_to”).
        /// </summary>
        [JsonProperty("link_type")]
        public IssueLinkTypeEnum? LinkType { get; set; }
    }
}
