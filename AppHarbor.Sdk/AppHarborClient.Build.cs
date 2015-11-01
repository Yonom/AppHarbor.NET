﻿using System.Collections.Generic;
using AppHarbor.Model;
using RestSharp;

namespace AppHarbor
{
	public partial class AppHarborClient
	{
		public Build GetBuild(string applicationSlug, string id)
		{
			CheckArgumentNull("applicationSlug", applicationSlug);

			var request = new RestRequest();
			request.Resource = "applications/{applicationSlug}/builds/{id}";
			request.AddParameter("applicationSlug", applicationSlug, ParameterType.UrlSegment);
			request.AddParameter("id", id, ParameterType.UrlSegment);

			return ExecuteGetKeyed<Build>(request);
		}

		public IEnumerable<Build> GetBuilds(string applicationSlug, int? count = null, int? offset = null)
		{
			CheckArgumentNull("applicationSlug", applicationSlug);

			var request = new RestRequest();
			request.Resource = "applications/{applicationSlug}/builds?count={count}&offset={offset}";
			request.AddParameter("applicationSlug", applicationSlug, ParameterType.UrlSegment);
			request.AddParameter("count", count.ToString(), ParameterType.UrlSegment);
			request.AddParameter("offset", offset.ToString(), ParameterType.UrlSegment);

			return ExecuteGetListKeyed<Build>(request);
        }

        public bool DeployBuild(string applicationSlug, string id)
        {
            CheckArgumentNull("name", applicationSlug);
            CheckArgumentNull("regionIdentifier", id);

            var request = new RestRequest(Method.POST);
            request.Resource = "applications/{applicationSlug}/builds/{id}/deploy";
            request.AddParameter("applicationSlug", applicationSlug, ParameterType.UrlSegment);
            request.AddParameter("id", id, ParameterType.UrlSegment);

            return this.ExecuteEdit(request);
        }
    }
}
