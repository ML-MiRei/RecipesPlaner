using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesPlan.Infrastructure.Data.Api.EdamamApi.Schemas
{
    public class _Links
    {
        [Newtonsoft.Json.JsonProperty("next")]
        public Next Next { get; set; }

    }

    public class Next
    {
        [Newtonsoft.Json.JsonProperty("href")]
        public string Href { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }
    }
}
