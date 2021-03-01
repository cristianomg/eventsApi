using System;
using System.Text.Json.Serialization;

namespace Api.Sample.Dtos
{
    public class DtoInsertEvent
    {
        /// <summary>
        /// Unix Timestamp ex: 1539112021301
        /// </summary>
        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }
        /// <summary>
        /// string separada por '.' ex: brasil.sudeste.sensor01 
        /// </summary>
        [JsonPropertyName("tag")]
        public string Tag { get; set; }
        /// <summary>
        /// dado coletado de um determinado sensor (podendo ser numérico ou string).
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }
        /// <summary>
        /// Retorna um dos items da tag, caso a tente acessar a posição de um item que não existe retorna ""
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public string GetItemFromTag(int position)
        {
            var tagArray = Tag.Split('.');
            return position < tagArray.Length ?
                   tagArray[position] :
                   "";
        }
    }
}
