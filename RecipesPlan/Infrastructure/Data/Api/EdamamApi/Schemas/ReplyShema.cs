namespace RecipesPlan.Infrastructure.Data.Api.EdamamApi.Schemas
{
    public class ReplyShema
    {
        [Newtonsoft.Json.JsonProperty("from")]
        public int From { get; set; }

        [Newtonsoft.Json.JsonProperty("to")]
        public int To { get; set; }

        [Newtonsoft.Json.JsonProperty("count")]
        public int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("_links")]
        public _Links Links { get; set; }

        [Newtonsoft.Json.JsonProperty("hits")]
        public Hit[] Hits { get; set; }
    }
}
