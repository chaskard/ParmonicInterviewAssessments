namespace Rate_LimitingMiddleware.Middlewares
{
    using Newtonsoft.Json;
    using System.Text;
    public static class Serialization
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectToSerialize"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this object objectToSerialize)
        {
            if (objectToSerialize == null)
            {
                return null;
            }

            return Encoding.Default.GetBytes(JsonConvert.SerializeObject(objectToSerialize));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arrayToDeserialize"></param>
        /// <returns></returns>
        public static T FromByteArray<T>(this byte[] arrayToDeserialize) where T : class
        {
            if (arrayToDeserialize == null)
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(Encoding.Default.GetString(arrayToDeserialize));
        }
    }
}
